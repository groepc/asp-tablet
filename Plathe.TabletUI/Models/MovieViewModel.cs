using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.TabletUI.Models
{
    public class MovieViewModel
    {
        private IMovieRepository repository;

        public MovieViewModel()
        {
            this.repository = DependencyResolver.Current.GetService<IMovieRepository>();
        }

       
    }
}