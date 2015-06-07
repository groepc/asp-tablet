using Plathe.Domain.Entities;
using Plathe.Domain.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.TabletUI.Models
{
    public class ShowViewModel
    {
        private IShowRepository repository;
        public Show Show { get; set; }
    }
}