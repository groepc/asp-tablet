using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Concrete
{
    class EFDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var movies = new List<Movie>
            {
                new Movie {
                    MovieID = 1,
                    Title = "Avengers: Age of Ultron",
                    Language = "EN",
                    Duration = 141,
                    MinimumAge = 12,
                    Description = "Wanneer een vredesprogramma van Tony Stark verschrikkelijk verkeerd gaat moet het team van superhelden de strijd aangaan met de kwade en alles vernietigende Ultron.",
                    ThreeDimensional = true,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/Avengersageofultron670x945.jpg",
                    RatingViolence = true,
                    RatingFear = true,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false
                },
                new Movie {
                    MovieID = 2,
                    Title = "De Masters",
                    Language = "NL",
                    Duration = 96,
                    MinimumAge = 12,
                    Description = "Wat als één van je maten met jouw tekst een hit scoort en je daarna niet meer kent? In de hilarische komedie De Masters overkomt het Aziz (Mimoun Oaissa).",
                    ThreeDimensional = false,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/demastersp1v2.jpg",
                    RatingViolence = false,
                    RatingFear = false,
                    RatingSex = true,
                    RatingDiscrimination = true,
                    RatingDrugs = false,
                    RatingLanguage = true
                },
                new Movie {
                    MovieID = 3,
                    Title = "Fast and Furious 7",
                    Language = "EN",
                    Duration = 137,
                    MinimumAge = 12,
                    Description = "Vin Diesel, Paul Walker en Dwayne Johnson zijn opnieuw samen te zien in de hoofdrollen van Fast & Furious 7",
                    ThreeDimensional = false,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/fast_amp_furious_7_02037619_ps_3_s-high.jpg",
                    RatingViolence = true,
                    RatingFear = false,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = true
                },
                new Movie {
                    MovieID = 4,
                    Title = "Get Hard",
                    Language = "EN",
                    Duration = 100,
                    MinimumAge = 12,
                    Description = "Als de steenrijke hedgefondsmanager James King (Will Ferrell) wegens fraude wordt veroordeeld tot een lange gevangenisstraf in San Quentin, krijgt hij van de rechter dertig dagen de tijd om zijn zaakjes te regelen.",
                    ThreeDimensional = false,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/gethardposter1.jpg",
                    RatingViolence = false,
                    RatingFear = true,
                    RatingSex = true,
                    RatingDiscrimination = true,
                    RatingDrugs = false,
                    RatingLanguage = true
                },
                new Movie {
                    MovieID = 5,
                    Title = "Mad Max: Fury Road",
                    Language = "EN",
                    Duration = 120,
                    MinimumAge = 16,
                    Description = "Regisseur George Miller, bedenker van het postapocalyptische genre en meesterbrein achter de legendarische Mad Max-cyclus, komt met “Mad Max: Fury Road”.",
                    ThreeDimensional = true,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/madmaxfuryroadp4.jpg",
                    RatingViolence = true,
                    RatingFear = false,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false
                },
                new Movie {
                    MovieID = 6,
                    Title = "Shaun het Schaap: De Film",
                    Language = "NL",
                    Duration = 85,
                    MinimumAge = 0,
                    Description = "Shaun het Schaap maakte zijn eerste optreden in de Oscarwinnende korte Wallace & Gromit-film A Close Shave (1995). Shaun is 's werelds bekendste schaap en weet televisiekijkers in al meer dan 170 landen te vermaken.",
                    ThreeDimensional = false,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/shaunhetschaapnlp2.jpg",
                    RatingViolence = false,
                    RatingFear = false,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false
                },
                new Movie {
                    MovieID = 7,
                    Title = "Home",
                    Language = "NL",
                    Duration = 137,
                    MinimumAge = 12,
                    Description = "De Moefs veroveren onze planeet. Het vindingrijke meisje Tip weet echter uit hun handen te blijven en ontmoet Oh, een verbannen Moef. Samen proberen ze de aarde te redden.",
                    ThreeDimensional = true,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/homenlposter2.jpg",
                    RatingViolence = false,
                    RatingFear = true,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false
                }
            };
            
            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();

            var rooms = new List<Room>
            {
                new Room {
                    RoomID = 1,
                    RoomName = "Zaal 1",
                    WheelchairAccess = true,
                    ThreeDimensional = true
                },
                new Room {
                    RoomID = 2,
                    RoomName = "Zaal 2",
                    WheelchairAccess = true,
                    ThreeDimensional = true
                },
                new Room {
                    RoomID = 3,
                    RoomName = "Zaal 3",
                    WheelchairAccess = true,
                    ThreeDimensional = false
                },
                new Room {
                    RoomID = 4,
                    RoomName = "Zaal 4",
                    WheelchairAccess = true,
                    ThreeDimensional = false
                },
                new Room {
                    RoomID = 5,
                    RoomName = "Zaal 5",
                    WheelchairAccess = false,
                    ThreeDimensional = false
                },
                new Room {
                    RoomID = 6,
                    RoomName = "Zaal 6",
                    WheelchairAccess = false,
                    ThreeDimensional = false
                }
            };
            rooms.ForEach(s => context.Rooms.Add(s));
            context.SaveChanges();

            var shows = new List<Show>
            {
                new Show {
                    ShowID = 1,
                    MovieID = 1,
                    RoomID = 1,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(18).AddMinutes(30),
                    ThreeDimensional = true
                },
                new Show {
                    ShowID = 2,
                    MovieID = 2,
                    RoomID = 2,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(19),
                    ThreeDimensional = false
                },
                new Show {
                    ShowID = 3,
                    MovieID = 3,
                    RoomID = 3,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(19).AddMinutes(30),
                    ThreeDimensional = true
                },
                new Show {
                    ShowID = 4,
                    MovieID = 4,
                    RoomID = 4,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(20),
                    ThreeDimensional = false
                },
                new Show {
                    ShowID = 5,
                    MovieID = 5,
                    RoomID = 5,
                    Subtitle = "NL",
                    StartingTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    ThreeDimensional = false
                },
                new Show {
                    ShowID = 6,
                    MovieID = 6,
                    RoomID = 6,
                    Subtitle = "FR",
                    StartingTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    ThreeDimensional = false
                }
            };

            shows.ForEach(s => context.Shows.Add(s));
            context.SaveChanges();


            var reservations = new List<Reservation>
            {
                new Reservation {
                    ReservationID = 1,
                    UniqueCode = "1234",
                    CreateOn = new DateTime(2015,01,01, 10,1,59),
                    PriceTotal = (decimal) 15.00
                },
                new Reservation {
                    ReservationID = 2,
                    UniqueCode = "ABC123",
                    CreateOn = new DateTime(2000,1,1, 23,4,23),
                    PriceTotal = (decimal) 10.00
                }
            };

            reservations.ForEach(s => context.Reservations.Add(s));
            context.SaveChanges();

            var tickets = new List<Ticket>
            {
                new Ticket {
                    TicketID = 1,
                    ShowID = shows.Single( i => i.ShowID == 1).ShowID,
                    ReservationID = reservations.Single( i => i.ReservationID == 1).ReservationID,
                    Price = (decimal) 8.50,
                    PopcornTime = false,
                    SeatNumber="20",
                    UniqueCode = "AWdfet43$#%#^%",
                    Options = "options",
                },
                new Ticket {
                    TicketID = 2,
                    ShowID = shows.Single( i => i.ShowID == 1).ShowID,
                    ReservationID = reservations.Single( i => i.ReservationID == 1).ReservationID,
                    Price = (decimal) 8.50,
                    PopcornTime = false,
                    SeatNumber="21",
                    UniqueCode = "AW23425@##@$",
                    Options = "options",
                }
            };

            tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();
        }
    }
}
