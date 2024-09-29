using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<User, int, bool>UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Book, int, bool> BookData()
        {
            return new BookRepo();
        }
        public static IRepo<Borrowing, int, bool> BorrowingData()
        {
            return new BorrowingRepo();
        }
        public static IRepo<Reminder, int, bool> ReminderData()
        {
            return new ReminderRepo();
        }
        public static IRepo<Library, int, bool> LibraryData()
        {
            return new LibraryRepo();
        }

        public static SRepo<string, List<Book>> SearchData() { return new BorrowingRepo(); }
        public static IAuth AuthData()
        {
            return new UserRepo();
        }
        public static UidRepo UidData()
        {
            return new BorrowingRepo();
        }

    }
}
