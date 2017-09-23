using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Calls.Models;
using Calls.ViewModels;

namespace Calls.Controllers
{
    public class CallController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Call/
        [AllowAnonymous]
        public async Task<ActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var calls = from c in db.Calls
                           select c;
            switch (sortOrder)
            {
                case "Name_desc":
                    // Can not use Calculated properties (eg., FullName) in 'OrderBy' and similar statements
                    calls = calls.OrderByDescending(c => c.nameFirst + c.nameLast);
                    break;
                case "Date":
                    calls = calls.OrderBy(c => c.dateLastVisit + c.nameFirst + c.nameLast);
                    break;
                case "Date_desc":
                    calls = calls.OrderByDescending(c => c.dateLastVisit + c.nameFirst + c.nameLast);
                    break;
                case "Barangay":
                    calls = calls.OrderBy(c => c.Barangay + c.City + c.nameFirst + c.nameLast);
                    break;
                default:
                    calls = calls.OrderBy(c => c.nameFirst + c.nameLast);
                    break;
            }

            /*An exception of type 'System.NotSupportedException' occurred in mscorlib.dll but was not handled in user code
             * Additional information: The specified type member 'FullName' is not supported in LINQ to Entities. 
             * Only initializers, entity members, and entity navigation properties are supported.             * 
             */
            return View(await calls.ToListAsync());
        }

        // GET: /Call/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = await db.Calls.FindAsync(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        // GET: /Call/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            CallViewModel callViewModel = new CallViewModel();
            return View(callViewModel);
        }

        // POST: /Call/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Create([Bind(Include = "CallId,CongregationID,Title,nameFirst,nameLast,Street,Barangay,City,State,dateFirstVisit,dateLastVisit,Status,Remarks")] Call call)
        {
            /* This is an example of the magic of model binding, that is-
             * - An HTML form has been posted back in
             * - The system knows what a call object is
             * - Maps HTML form data (using Name attribute of an 'input' element, for example) to a call object
             * 
             * Watch "Developing ASP.NET MVC 4 Applications: (03) Developing MVC 4 Controllers". Jump to Time: 24:30 
            */
            if (ModelState.IsValid)  // Tip: Profuse model with validation attributes
            {
                try
                {
                    db.Calls.Add(call);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error: ", ex.Message);
                    return View(call);
                }
            }

            CallViewModel callViewModel = new CallViewModel(call);
            return View(callViewModel);
        }

        // GET: /Call/Edit/5
        [AllowAnonymous]
        public async Task<ActionResult> Edit(int? id)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = await db.Calls.FindAsync(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call); */

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = await db.Calls.FindAsync(id); 
            if (call == null)
            {
                return HttpNotFound();
            }
            ViewBag.InitialScreen = TempData["Set"];
            CallViewModel callViewModel = new CallViewModel(call);
            return View(callViewModel);
        }

        // POST: /Call/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Edit([Bind(Include = "CallId,CongregationID,Title,nameFirst,nameLast,Street,Barangay,City,State,dateFirstVisit,dateLastVisit,Status,Remarks")] Call call)
        {
            /* Notice that the code to update the database doesn’t execute unless the ModelState.IsValid property is equal to true. 
             * This safety code is included in case the user doesn‘t allow JavaScript to run on his or her browser and serves as a fallback for client-side validation.
             * 
             * See article: 'Manage Data in HTML5 Forms with Entity Framework' (http://msdn.microsoft.com/en-us/magazine/hh875175.aspx)
             * in section: 'Updating the Data Source with Entity Framework'
             */
            if (ModelState.IsValid)
            {
                db.Entry(call).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(call);
        }

        // GET: /Call/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = await db.Calls.FindAsync(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        // POST: /Call/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Call call = await db.Calls.FindAsync(id);
            db.Calls.Remove(call);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
