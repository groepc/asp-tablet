using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    public interface IRowRepository
    {
        IEnumerable<Row> Rows { get; }
    }
}
