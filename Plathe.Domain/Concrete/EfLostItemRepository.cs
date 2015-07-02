using System.Collections.Generic;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Concrete
{
    public class EfLostItemRepository : ILostItemRepository
    {
        private EfDbContext _context = new EfDbContext();

        public IEnumerable<LostItem> LostItems
        {
            get { return _context.LostItems; }
        }

        //Author = Mieke

        public void SaveLostItem(LostItem lostitem)
        {
            if (lostitem.LostItemId == 0)
            {
                _context.LostItems.Add(lostitem);
            }
            else
            {
                LostItem dbEntry = _context.LostItems.Find(lostitem.LostItemId);
                if (dbEntry != null)
                {
                    dbEntry.Name = lostitem.Name;
                    dbEntry.Location = lostitem.Location;
                    dbEntry.Description = lostitem.Description;
                    dbEntry.TimeFound = lostitem.TimeFound;
                    dbEntry.Collected = lostitem.Collected;
                }
            }
            _context.SaveChanges();
        }

        public LostItem DeleteLostItem(int lostItemId)
        {
            LostItem dbEntry = _context.LostItems.Find(lostItemId);
            if (dbEntry != null)
            {
                _context.LostItems.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}