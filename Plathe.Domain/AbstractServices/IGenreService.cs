﻿using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.AbstractServices
{
    public interface IGenreService
    {
        int findIdGenreByName(string genreString);
    }
}
