using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniCore_Francis.Data;
using MiniCore_Francis.Models;

namespace MiniCore_Francis.Controllers
{
    public class MiniCoresController : Controller
    {
        private readonly AppDBContext _context;

        public MiniCoresController(AppDBContext context)
        {
            _context = context;
        }

        // GET: MiniCores
        public async Task<IActionResult> Index()
        {
            return _context.minicores != null ?
                View(await _context.minicores.ToListAsync()) :
                Problem("Entity set 'AppDBContext.minicores'  is null.");
        }

        public async Task<IActionResult> RandomData()
        {

            var minicores = await _context.minicores.ToListAsync();
            int averageDailyPassesUsed = 4;

            Random random = new Random();

            foreach(var minicore in minicores)
            {
                int DaysToExpire = 0;
                int randomPassUse = 0;

                if (minicore.CurrentPasses > 10)
                {
                    randomPassUse = random.Next(0, 11);
                }
                else
                {
                    randomPassUse = random.Next(0, minicore.CurrentPasses + 1);
                }

                minicore.CurrentDate = DateTime.Now;

                minicore.UsedPasses += randomPassUse;

                if ((minicore.CurrentPasses - randomPassUse) > 0)
                {
                    minicore.CurrentPasses = minicore.CurrentPasses - randomPassUse;
                }
                else
                {
                    minicore.CurrentPasses = 0;
                }
                
                
                int auxCP = minicore.CurrentPasses;
                
                while(auxCP > 0)
                {
                    auxCP -= averageDailyPassesUsed;
                    DaysToExpire++;
                }
                minicore.ExpirationDate = minicore.CurrentDate.AddDays(DaysToExpire);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
