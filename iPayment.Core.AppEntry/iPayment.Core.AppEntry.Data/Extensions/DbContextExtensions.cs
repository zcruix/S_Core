using System;
using System.Data.Entity;
using System.Linq;
using iPayment.Core.AppEntry.Data.Model;

namespace iPayment.Core.AppEntry.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static T SaveChanges<T>(this DbContext db, Func<T> doOperation)
        {
            var result = doOperation.Invoke();
            db.SaveChanges();
            return result;
        }
     
        public static T FastFind<T>(this DbSet<T> dbSet, int applicationFormKey)
            where T : ApplicationFormSectionBase
        {
            var entity = dbSet.Local.SingleOrDefault(x => x.ApplicationFormKey == applicationFormKey);
            return entity ?? dbSet.SingleOrDefault(x => x.ApplicationFormKey == applicationFormKey);
        }
   }
}