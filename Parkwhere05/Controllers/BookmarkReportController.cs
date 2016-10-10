using Parkwhere05.DAL;
using Parkwhere05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parkwhere05.Controllers
{
    public class BookmarkReportController : GeneralController<BookmarkReport>
    {
        //To store most frequent dates based on location
        List<BookmarkReport> FrequentDatesBasedOnLocation;
        IEnumerable<BookmarkReport> FrequentDatesBasedOnLocationInput;

        public BookmarkReportController()
        {
            dataGateway = new BookmarkReportGateway();
            
        }

        // GET: BookmarkReport
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.UnsortedBookmarkReportList = FrequentDatesBasedOnLocation = ((BookmarkReportGateway)dataGateway).FrequentBookmarks();

            return View(FrequentDatesBasedOnLocation);
        }

        // POST: BookmarkReport
        [HttpPost]
        public PartialViewResult ShowSearchResults()
        {
            //System.Threading.Thread.Sleep(3000);
            string address = Request.Form["carparkNo"];
            FrequentDatesBasedOnLocationInput = ((BookmarkReportGateway)dataGateway).FrequentBookmarksBasedOnLocation(address);
            return PartialView("Index", FrequentDatesBasedOnLocationInput);
            //return View();
        }
    }
}