using Plathe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plathe.DAL
{
    public class CinemaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CinemaContext>
    {
        protected override void Seed(CinemaContext context)
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
                    Title = "Vin Diesel, Paul Walker en Dwayne Johnson zijn opnieuw samen te zien in de hoofdrollen van Fast & Furious 7",
                    Language = "EN",
                    Duration = 137,
                    MinimumAge = 12,
                    Description = "Wat als één van je maten met jouw tekst een hit scoort en je daarna niet meer kent? In de hilarische komedie De Masters overkomt het Aziz (Mimoun Oaissa).",
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

            var shows = new List<Show>
            {
                new Show {
                    ShowID = 1,
                    MovieID = 1,
                    Subtitle = "EN",
                    StartingTime = "20:00",
                    ThreeDimensional = true
                },
                new Show {
                    ShowID = 2,
                    MovieID = 2,
                    Subtitle = "EN",
                    StartingTime = "19:00",
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
                    CreateOn = new DateTime(2000,1,1),
                    PriceTotal = 10.00M
                },
                new Reservation {
                   ReservationID = 2,
                    UniqueCode = "ABC123",
                    CreateOn = new DateTime(2000,1,1),
                    PriceTotal = 10.00M
                }
            };

            reservations.ForEach(s => context.Reservations.Add(s));
            context.SaveChanges();
        }
    }
}