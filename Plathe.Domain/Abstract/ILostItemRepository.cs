using System.Collections.Generic;
using Plathe.Domain.Entities;

//Author = Mieke

namespace Plathe.Domain.Abstract
{
    public interface ILostItemRepository
    {
        IEnumerable<LostItem> LostItems { get; }

        void SaveLostItem(LostItem lostItem);

        LostItem DeleteLostItem(int lostItemId);
    }
}