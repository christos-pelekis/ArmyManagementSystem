using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyManagementSystem.Data;
using ArmyManagementSystem.Models;

namespace ArmyManagementSystem.Controllers
{
    public class StaffMembersController : Controller
    {
        private readonly ArmyManagementSystemDbContext _context;

        public StaffMembersController(ArmyManagementSystemDbContext context)
        {
            _context = context;
        }

        // GET: StaffMembers
        public async Task<IActionResult> Index()
        {
              return _context.StaffMembers != null ? 
                          View(await _context.StaffMembers.ToListAsync()) :
                          Problem("Entity set 'ArmyManagementSystemDbContext.StaffMembers'  is null.");
        }

        // GET: StaffMembers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffMember = await _context.StaffMembers.FirstOrDefaultAsync(m => m.StaffMemberId == id);

            if (staffMember == null)
            {
                return NotFound();
            }

            return View(staffMember);
        }

        // GET: StaffMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffMembers/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffMemberId,SerialNumber,Rank,Surname,Name,FatherName,DateOfBirth,ColorOfHair,ColorOfEyes,Height,BloodType,Address,PhoneNumber,Email")] StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                staffMember.StaffMemberId = Guid.NewGuid();
                _context.Add(staffMember);
                await _context.SaveChangesAsync();
                TempData["CreateStaffMemberSuccess"] = "Το νέο μέλος προσωπικού δημιουργήθηκε επιτυχώς!";
                return RedirectToAction(nameof(Index));
            }
            return View(staffMember);
        }

        // GET: StaffMembers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.StaffMembers == null)
            {
                return NotFound();
            }

            var staffMember = await _context.StaffMembers.FindAsync(id);

            if (staffMember == null)
            {
                return NotFound();
            }			
			return View(staffMember);
        }

        // POST: StaffMembers/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StaffMemberId,SerialNumber,Rank,Surname,Name,FatherName,DateOfBirth,ColorOfHair,ColorOfEyes,Height,BloodType,Address,PhoneNumber,Email")] StaffMember staffMember)
        {
            if (id != staffMember.StaffMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffMemberExists(staffMember.StaffMemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
				TempData["EditStaffMemberSuccess"] = "Το μέλος προσωπικού ενημερώθηκε επιτυχώς!";
				return RedirectToAction(nameof(Index));
            }
            return View(staffMember);
        }

        // GET: StaffMembers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.StaffMembers == null)
            {
                return NotFound();
            }

            var staffMember = await _context.StaffMembers.FirstOrDefaultAsync(m => m.StaffMemberId == id);
            
            if (staffMember == null)
            {
                return NotFound();
            }

            return View(staffMember);
        }

        // POST: StaffMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.StaffMembers == null)
            {
                return Problem("Entity set 'ArmyManagementSystemDbContext.StaffMembers'  is null.");
            }

            var staffMember = await _context.StaffMembers.FindAsync(id);

            if (staffMember != null)
            {
                _context.StaffMembers.Remove(staffMember);
            }
            
            await _context.SaveChangesAsync();
			TempData["DeleteStaffMemberSuccess"] = "Το μέλος προσωπικού διαγράφηκε επιτυχώς!";
			return RedirectToAction(nameof(Index));
        }

        private bool StaffMemberExists(Guid id)
        {
          return (_context.StaffMembers?.Any(e => e.StaffMemberId == id)).GetValueOrDefault();
        }
    }
}
