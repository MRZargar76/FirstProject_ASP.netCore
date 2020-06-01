﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Mehr.Classes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Controllers
{
    public class BankController : Controller
    {
        public IBankRepository banks;
        private readonly IHostingEnvironment _hostingEnvironment;

        public BankController(IHostingEnvironment hostingEnvironment, MyContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            banks = new BankRepository(context);
        }


        // GET: App/Bank/Details/5
        public async Task<IActionResult> Details(int? id, string FromDate = "", string ToDate = "")
        {
            if (id == null)
            {
                return NotFound();
            }

            DateTime From = new DateTime();
            DateTime To = new DateTime();

            if (FromDate == "")
            {
                string temp = DateTime.Today.ToSolar();
                temp = temp.Substring(0, temp.Length - 2) + "01";
                From = Convert.ToDateTime(temp.ToAD());
            }
            else
            {
                try
                {
                    From = Convert.ToDateTime(FromDate.ToAD());
                }
                catch (Exception)
                {
                    ViewBag.err = new Exception("Invalid persian time format ...");
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
                catch (Exception)
                {
                    ViewBag.err = new Exception("Invalid persian time format ...");
                    return View("Error");
                }
            }

            Bank bank;
            try
            {
                bank = await banks.GetByIdAsync(id.Value);
            }
            catch (Exception ex)
            {
                ViewBag.err = ex;
                return View("Error");
            }

            ViewBag.maxAmount = 50000;
            if (bank.Transactions.Count() > 0)
            {
                double max = bank.Transactions.Select(x => x.Amount).Max();
                double div = Math.Pow(10, max.ToString().Count() - 1);
                double round = Math.Ceiling(max / div) * div;
                ViewBag.maxAmount = round;
            }
            ViewBag.FromDate = From.ToShortDateString();
            ViewBag.ToDate = To.ToShortDateString();
            ViewBag.ChartData = "[125, 200, 125, 225, 125, 200, 125, 225, 175, 275, 220]";
            return View(bank);
        }


        // GET: Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bank/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("BankID,BankName,Owner,AccountNumber,CardNumber,ShebaNumber")] Bank bank, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                saveImgBank(ref bank, img);

                try
                {
                    await banks.InsertAsync(bank);
                    await banks.saveAsync();
                    this.SetViewMessage("New Bank Created successfully.", WebMessageType.Success);

                }
                catch (Exception ex)
                {
                    this.SetViewMessage(ex.Message, WebMessageType.Danger);
                }
            }
            else
            {
                this.SetViewMessage("Please Complete fields ...", WebMessageType.Warning);
            }
            return RedirectToAction("Banks", "Home");
        }

        // GET: Bank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bank/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void saveImgBank(ref Bank bank, IFormFile img)
        {
            if (img != null)
            {
                bank.pic = Guid.NewGuid() + Path.GetExtension(img.FileName);
                string picPath = _hostingEnvironment.WebRootPath
                                + @"\images\Banks\"
                                + bank.pic;

                using (var stream = new FileStream(picPath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
        }

    }
}