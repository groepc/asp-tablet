using System.Collections.Generic;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Abstract
{
    public interface IRowRepository
    {
        IEnumerable<Row> Rows { get; }
    }
}
