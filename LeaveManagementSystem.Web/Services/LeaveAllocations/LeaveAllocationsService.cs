using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor,
        UserManager<ApplicationUser> _userManager, IMapper _mapper) : ILeaveAllocationsService
    {

        //private async Task<ApplicationUser> GetCurrentUserAsync()
        //{
        //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        //    if (user == null) throw new Exception("User not found");
        //    return user;
        //}
        public async Task AllocateLeave(string employeeId)
        {
            // Get all the leave types
            
            var leaveTypes = await _context.LeaveTypes
                .Where(q => !q.LeaveAllocations.Any(x=> x.EmployeeId == employeeId))
                .ToListAsync();
   

            // Get the current period based on the year
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            var monthRemaining = period.EndDate.Month - currentDate.Month;
                                       

            // Foreach leave type, create a new allocation entry

            foreach (var leaveType in leaveTypes)
            {
                //works, but not best practice
                //var allocationExists = await AllocationExists(employeeId, leaveType.Id, period.Id);
                //if(allocationExists)
                //{
                //    continue;
                //}
                var acurralDate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId, 
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(acurralDate * monthRemaining)
                };
                
                _context.Add(leaveAllocation);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId) 
        {
            var user = string.IsNullOrEmpty(userId)
                ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User)
                : await _userManager.FindByIdAsync(userId);

            var allocations = await GetAllocations(user.Id);
            var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
            var leaveTypesCount = await _context.LeaveTypes.CountAsync();

            var employeeAllocation = new EmployeeAllocationVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                LeaveAllocations = allocationVmList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count 
            };
            return employeeAllocation;
        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employess = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());
            return employess;
        }

        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {
            //string employeeId = string.Empty;
            //if (string.IsNullOrEmpty(userId))
            //{
            //    employeeId = userId;
            //}
            //else
            //{
            //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            //    employeeId = user.Id;
            //}

            var currentDate = DateTime.Now;
            //var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            //var leaveAllocations = await _context.LeaveAllocations
            //    .Include(q=> q.leaveType)
            //    .Include(q=> q.Period)
            //    .Where(q => q.EmployeeId == user.Id && q.PeriodId == Period.Id)
            //    .ToListAsync();

            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.leaveType)
                .Include(q => q.Period)
                .Where(q => q.EmployeeId == userId && q.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocations(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                .Include(q => q.leaveType)
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

            return model;
        }   

        public async Task EditAllocation(LeaveAllocationEditVM allocationEditVm)
        {
            
            await _context.LeaveAllocations
                .Where(q => q.Id == allocationEditVm.Id)
                .ExecuteUpdateAsync(q => q.SetProperty(x => x.Days, allocationEditVm.Days));
        } 

        private async Task<bool> AllocationExists(string userId, int leaveTypeId, int periodId)
        {
            var exists = await _context.LeaveAllocations.AnyAsync(q =>
                    q.EmployeeId == userId 
                    && q.LeaveTypeId == leaveTypeId 
                    && q.PeriodId == periodId
            );

            return exists;
        }

       
    }



}


//var leaveAllocation = await GetEmployeeAllocations(allocationEditVm.Id);
//if(leaveAllocation == null)
//{
//    throw new Exception("Allocation not found");
//}

//leaveAllocation.Days = allocationEditVm.Days;
//option 1 _context.Update(leaveAllocation);
//option 2 _context.Entry(leaveAllocation).State = EntityState.Modified;
//await _context.SaveChangesAsync();
