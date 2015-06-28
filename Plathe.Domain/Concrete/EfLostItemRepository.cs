using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfLostItemRepository : ILostItemRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<LostItem> LostItems
        {
            get { return context.LostItems; }
        }

        //Author = Mieke

        public void SaveLostItem(LostItem lostitem)
        {
            if (lostitem.LostItemId == 0)
            {
                context.LostItems.Add(lostitem);
            }
            else
            {
                LostItem dbEntry = context.LostItems.Find(lostitem.LostItemId);
                if (dbEntry != null)
                {
                    dbEntry.Name = lostitem.Name;
                    dbEntry.Location = lostitem.Location;
                    dbEntry.Description = lostitem.Description;
                    dbEntry.TimeFound = lostitem.TimeFound;
                    dbEntry.Collected = lostitem.Collected;
                }
            }
            context.SaveChanges();
        }

        public LostItem DeleteLostItem(int lostItemId)
        {
            LostItem dbEntry = context.LostItems.Find(lostItemId);
            if (dbEntry != null)
            {
                context.LostItems.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}