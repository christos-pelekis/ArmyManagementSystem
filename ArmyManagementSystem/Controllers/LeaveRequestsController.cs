using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyManagementSystem.Data;
using ArmyManagementSystem.Models;

namespace ArmyManagementSystem.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly ArmyManagementSystemDbContext _context;

        public LeaveRequestsController(ArmyManagementSystemDbContext context)
        {
            _context = context;
        }

		// GET: LeaveRequests/ByStaffMember/{staffMemberId}
		public async Task<IActionResult> ByStaffMember(Guid? staffMemberId)
		{
			if (staffMemberId == null)
			{
				return NotFound();
			}
            var leaveRequestsByStaffMember = await _context.LeaveRequests
		        .Include(l => l.StaffMember)
		        .Where(l => l.StaffMemberId == staffMemberId.GetValueOrDefault())
		        .ToListAsync();
			if (leaveRequestsByStaffMember == null)
			{
				return NotFound();
			}
            ViewBag.StaffMemberId = staffMemberId;
            return View(leaveRequestsByStaffMember);
		}		

        // GET: LeaveRequests/Create
        public IActionResult Create(Guid? staffMemberId)
        {
            ViewBag.StaffMemberId = staffMemberId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid staffMemberId, LeaveRequest leaveRequest)
        {
            leaveRequest.LeaveRequestId = Guid.NewGuid();
            _context.Add(leaveRequest);
            await _context.SaveChangesAsync();
            TempData["CreateLeaveRequestSuccess"] = "Η άδεια καταχωρήθηκε επιτυχώς!";
            return RedirectToAction("ByStaffMember", "LeaveRequests", new { staffMemberId = leaveRequest.StaffMemberId });           
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveRequest = await _context.LeaveRequests
                .Include(l => l.StaffMember)
                .FirstOrDefaultAsync(m => m.LeaveRequestId == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid staffMemberId, Guid id)
        {
            if (_context.LeaveRequests == null)
            {
                return Problem("Entity set 'ArmyManagementSystemDbContext.LeaveRequests'  is null.");
            }
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
            }            
            await _context.SaveChangesAsync();
            TempData["DeleteLeaveRequestSuccess"] = "Η άδεια διαγράφηκε επιτυχώς!";
            return RedirectToAction(nameof(ByStaffMember), new { staffMemberId = staffMemberId });
        }

        private bool LeaveRequestExists(Guid id)
        {
          return _context.LeaveRequests.Any(e => e.LeaveRequestId == id);
        }
    }
}
