using Parkwhere05.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parkwhere05.DAL
{
    public class BookmarkReportGateway : DataGateway<BookmarkReport>
    {
        List<BookmarkReport> BookmarkReportsList;

        public BookmarkReportGateway()
        {
            this.data = db.Set<BookmarkReport>();
            //BookmarkReportsList = new List<BookmarkReport>();
        }

        public List<BookmarkReport> FrequentBookmarks()
        {
            //BookmarkReportsList = data.SqlQuery("SELECT * FROM carpark C, bookmark B WHERE C.id = B.carparkId GROUP BY B.User_UserId ORDER BY COUNT(*) DESC ").ToList();

            BookmarkReportsList = data.SqlQuery("SELECT COUNT(B.User_UserId) as UserCount, B.date, C.carparkNo, C.address, B.BookmarkId, B.carparkId, C.x_coord, C.y_coord  FROM carpark C, bookmark B WHERE C.id = B.carparkId GROUP BY B.User_UserId ORDER BY COUNT(*)").ToList();

            //List<UnsortedBookMarkObjs> UnsortedBookMarkObjsList = new List<UnsortedBookMarkObjs>();

            //for (int i = 0; i < UnsortedBookmarkReportsList.Count; i++)
            //{
            //    var unsortedBookMarkObj = new UnsortedBookMarkObjs();
            //    unsortedBookMarkObj.User_UserId_Count = UnsortedBookmarkReportsList[i].UserCount;
            //    unsortedBookMarkObj.address = UnsortedBookmarkReportsList[i].address;
            //    unsortedBookMarkObj.carparkNo = UnsortedBookmarkReportsList[i].carparkNo;
            //    unsortedBookMarkObj.date = UnsortedBookmarkReportsList[i].date;

            //    UnsortedBookMarkObjsList.Add(unsortedBookMarkObj);
            //}

            //var unsortedBookMarkObjTemp = new UnsortedBookMarkObjs();

            //for (int i = 0; i < UnsortedBookMarkObjsList.Count; i++)
            //{
            //    for (int sort = 0; sort < UnsortedBookMarkObjsList.Count - 1; sort++)
            //    {
            //        if (UnsortedBookMarkObjsList[sort].User_UserId_Count > UnsortedBookMarkObjsList[sort + 1].User_UserId_Count)
            //        {
            //            unsortedBookMarkObjTemp = UnsortedBookMarkObjsList[sort + 1];
            //            UnsortedBookMarkObjsList[sort + 1] = UnsortedBookMarkObjsList[sort];
            //            UnsortedBookMarkObjsList[sort] = unsortedBookMarkObjTemp;
            //        }
            //    }
            //}


            //for (int i=0; i< UnsortedBookMarkObjsList.Count; i++)
            //{
            //    var bookmarkReportObj = new BookmarkReport();
            //    bookmarkReportObj.address = UnsortedBookMarkObjsList[i].address;
            //    bookmarkReportObj.date = UnsortedBookMarkObjsList[i].date;
            //    bookmarkReportObj.carparkNo = UnsortedBookMarkObjsList[i].carparkNo;

            //    BookmarkReportsList.Add(bookmarkReportObj);
            //}

            return BookmarkReportsList;
        }

        public IEnumerable<BookmarkReport> FrequentBookmarksBasedOnLocation(string carparkNo)
        {
            BookmarkReportsList = data.SqlQuery("SELECT * FROM carpark C, bookmark B WHERE C.id = B.carparkId AND C.carparkNo LIKE '%" + carparkNo + "' GROUP BY B.User_UserId ORDER BY COUNT(*) DESC ").ToList();
            return BookmarkReportsList;
        }


    }

    //public class UnsortedBookMarkObjs {

    //    [Key]
    //    public int User_UserId_Count { get; set; }
    //    public Nullable<System.DateTime> date { get; set; }
    //    public string carparkNo { get; set; }
    //    public string address { get; set; }

    //}
}