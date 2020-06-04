using Microsoft.AspNetCore.Mvc;
using DataLayer;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Mehr.Classes;

namespace Mehr.ViewComponents
{
    [ViewComponent]
    public class DetailsColleagueTable : ViewComponent
    {
        private ISponsorRepository sponsors;
        private IColleageRepository colleages;

        public DetailsColleagueTable(MyContext context)
        {
            sponsors = new SponsorRepository(context);
            colleages = new ColleagueRepository(context);
        }

        public async Task<IViewComponentResult> InvokeAsync(int id, string FromDate, string ToDate)
        {
            DateTime From = new DateTime();
            DateTime To = new DateTime();

            if (FromDate == "")
            {
                From = Convert.ToDateTime(new DateTime().getFirstSolarMonth().ToAD());
            }
            else
            {
                try
                {
                    From = Convert.ToDateTime(FromDate.ToAD());
                }
                catch (Exception ex)
                {
                    ViewBag.err = ex;
                    return View("Error");
                }
            }

            if (ToDate == "")
            {
                To = DateTime.Today;
            }
            else
            {
                try
                {
                    To = Convert.ToDateTime(ToDate.ToAD());
                }
                catch (Exception ex)
                {
                    ViewBag.err = ex;
                    return View("Error");
                }
            }

            var colleague = await colleages.GetByIdAsync(id);

            List<SponsorTransaction> colleagusTransactios = new List<SponsorTransaction>();
            double sumAmounts = 0;

            foreach (Sponsor sponsor in colleague.Sponsors)
            {   
                var sponsorTransactions = await sponsors.GetFromToTransactionBySponsorIdAsync(sponsor.SponsorID, From, To.AddDays(1));
                colleagusTransactios.AddRange(sponsorTransactions);
                sumAmounts += sponsorTransactions.Select(x => (x.MyTransaction?.Amount ?? 0) + (x.MyReceipt?.Amount ?? 0)).Sum();
            }

            TempData["maxAmount"] = 50000;
            if (colleagusTransactios.Count() > 0)
            {
                double max1 = Convert.ToDouble(colleagusTransactios.Select(x => x.MyTransaction?.Amount ?? 0).Max());
                double max2 = Convert.ToDouble(colleagusTransactios.Select(x => x.MyReceipt?.Amount ?? 0).Max());
                double max = max1 > max2 ? max1 : max2;
                double div = Math.Pow(10, max.ToString().Count() - 1);
                double round = Math.Ceiling(max / div) * div;
                TempData["maxAmount"] = round;
            }
            TempData["FromDate"] = From.ToShortDateString();
            TempData["ToDate"] = To.ToShortDateString();
            return View(colleagusTransactios);
        }
    }
}
