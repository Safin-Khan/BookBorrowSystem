using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ReminderRepo : Repo, IRepo<Reminder, int, bool>
    {
        public bool Create(Reminder obj)
        {
            db.Reminders.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Reminders.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Reminder> Get()
        {
            return db.Reminders.ToList();
        }

        public Reminder Get(int id)
        {
            return db.Reminders.Find(id);
        }

        public bool Update(Reminder obj)
        {
            var exobj = Get(obj.ID);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
