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
            BookmarkReportsList = new List<BookmarkReport>();
        }

        public List<BookmarkReport> FrequentBookmarks()
        {
            //BookmarkReportsList = data.SqlQuery("SELECT * FROM carpark C, bookmark B WHERE C.id = B.carparkId GROUP BY B.User_UserId ORDER BY COUNT(*) DESC LIMIT 1000").ToList();

            /*from assignment 1*/
            //BookmarkReportsList = data.SqlQuery("SELECT COUNT(B.User_UserId) as UserCount, B.date, C.carparkNo, C.address, B.BookmarkId, B.carparkId, C.x_coord, C.y_coord  FROM carpark C, bookmark B WHERE C.id = B.carparkId GROUP BY B.date ORDER BY COUNT(*)").ToList();

            /*for assignment 2 - unoptimised*/
            BookmarkReportsList = data.SqlQuery("SELECT User_email, COUNT(B.User_UserId) as UserCount, B.date, C.carparkNo, C.address, B.BookmarkId, B.carparkId, C.x_coord, C.y_coord  FROM parkwhere.carpark C, parkwhere.bookmark B, parkwhere.user U WHERE C.id = B.carparkId AND B.User_UserId = U.UserId GROUP BY B.date").ToList();

            /*for assignment 2 - optimised*/
            //BookmarkReportsList = data.SqlQuery("SELECT U.User_email, query2.UserId, query2.UserCount, query2.date, query2.carparkNo, query2.address, query2.BookmarkId, query2.carparkId, query2.x_coord, query2.y_coord FROM parkwhere.user U, (SELECT B.User_UserId as UserId, COUNT(B.User_UserId) as UserCount, B.date as date, C.carparkNo as carparkNo, C.address as address, B.BookmarkId as BookmarkId, B.carparkId as carparkId, C.x_coord as x_coord, C.y_coord as y_coord FROM parkwhere.carpark C, parkwhere.bookmark B WHERE C.id = B.carparkId GROUP BY B.date ORDER BY COUNT(*)) as query2 WHERE U.userId = query2.UserId").ToList();

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
            BookmarkReportsList = data.SqlQuery("SELECT * FROM carpark C, bookmark B WHERE C.id = B.carparkId AND C.carparkNo LIKE '%" + carparkNo + "' GROUP BY B.User_UserId ORDER BY COUNT(*) DESC  LIMIT 10000").ToList();
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