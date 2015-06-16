using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plathe.Domain.Entities;

namespace Plathe.Domain.Extensions
{
    class CalculatePrice
    {
        private Array dateTimes = new DateTime[]
        {
            new DateTime(2015, 12, 25),
            new DateTime(2015, 12, 26),
        };

        public decimal GetTicketPricePrice(string type, Show show, bool secretMovie)
        {
            decimal price = GetDefaultMoviePrice(show, secretMovie);
            switch (type)
            {
                case "adult":
                    return Adult(price);
                case "adultsplus":
                    return Adultplus(show, price);
                case "children":
                    return Children(show, price);
                case "students":
                    return Student(show, price);
                case "popcorn":
                    return Popcorn(price);
                case "vip":
                    return Vip(price);

                default:
                    return price;
            }
        }

        private decimal GetDefaultMoviePrice(Show show, bool secretMovie)
        {
            decimal price = (decimal)0.00;

            if (show.Movie.Duration > 120)
            {
                price = (decimal)9.00;
            }
            else
            {
                price = (decimal)8.50;
            }

            if (show.Movie.ThreeDimensional == true)
            {
                price += (decimal)2.50;
            }

            if (secretMovie == true) {
                price -= (decimal)2.50;
            }

            return price;
        }

        private decimal Adult(decimal price)
        {
            return price;
        }

        private decimal Adultplus(Show show, decimal price)
        {
            var dayOfWeek = (int)(show.StartingTime.DayOfWeek + 6) % 7;

            // only change ticket price between monday and thursday
            if (dayOfWeek >= 0 && dayOfWeek <= 3 && !dateTimes.Equals(show.StartingTime.Date))
            {
                return price - (decimal)1.50;
            }
            return price;
        }

        private decimal Children(Show show, decimal price)
        {
            if (show.StartingTime.Hour <= 18 && show.Movie.Language == "NL")
            {
                return price - (decimal)1.50M;
            }

            return price;
        }

        private decimal Popcorn(decimal price)
        {
            return price + (decimal)5.00;
        }

        private decimal Student(Show show, decimal price)
        {
            var dayOfWeek = (int)(show.StartingTime.DayOfWeek + 6) % 7;

            // only change ticket price between monday and thursday
            if (dayOfWeek >= 0 && dayOfWeek <= 3)
            {
                return price - (decimal)1.50M;
            }
            return price;
        }

        //VIP-kaartje
        private decimal Vip(decimal price)
        {
            return price + (decimal)10.00;
        }

    }
}
