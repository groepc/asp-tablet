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

        public decimal getTicketPricePrice(string type, Show show, bool secretMovie)
        {
            decimal price = getDefaultMoviePrice(show, secretMovie);
            switch (type)
            {
                case "adult":
                    return adult(price);
                case "adultsplus":
                    return adultplus(show, price);
                case "children":
                    return children(show, price);
                case "students":
                    return student(show, price);
                case "popcorn":
                    return popcorn(price);

                default:
                    return price;
            }
        }

        private decimal getDefaultMoviePrice(Show show, bool secretMovie)
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

        private decimal adult(decimal price)
        {
            return price;
        }

        private decimal adultplus(Show show, decimal price)
        {
            var dayOfWeek = (int)(show.StartingTime.DayOfWeek + 6) % 7;

            // only change ticket price between monday and thursday
            if (dayOfWeek >= 0 && dayOfWeek <= 3 && !dateTimes.Equals(show.StartingTime.Date))
            {
                return price - (decimal)1.50;
            }
            return price;
        }

        private decimal children(Show show, decimal price)
        {
            if (show.StartingTime.Hour <= 18 && show.Movie.Language == "NL")
            {
                return price - (decimal)1.50M;
            }

            return price;
        }

        private decimal popcorn(decimal price)
        {
            return price + (decimal)5.00;
        }

        private decimal student(Show show, decimal price)
        {
            var dayOfWeek = (int)(show.StartingTime.DayOfWeek + 6) % 7;

            // only change ticket price between monday and thursday
            if (dayOfWeek >= 0 && dayOfWeek <= 3)
            {
                return price - (decimal)1.50M;
            }
            return price;
        }

    }
}
