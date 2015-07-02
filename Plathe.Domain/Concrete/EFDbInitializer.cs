using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Plathe.Domain.Entities;
using Plathe.Domain.Extensions;

namespace Plathe.Domain.Concrete
{

    internal class EfDbInitializer : DropCreateDatabaseAlways<EfDbContext>

        //class EfDbInitializer : DropCreateDatabaseIfModelChanges<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {

            var usermanager = new UserManager<User>(new UserStore<User>(context));
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // allow alphanumeric characters in username
            usermanager.UserValidator = new UserValidator<User>(usermanager)
            {
                AllowOnlyAlphanumericUserNames = false
            };


            usermanager.Create(new User()
            {
                Id = "1",
                UserName = "manager@plathe.nl",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            }, "wachtwoord");

            usermanager.Create(new User()
            {
                Id = "2",
                UserName = "cassiere@plathe.nl",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            }, "wachtwoord");

            usermanager.Create(new User()
            {
                Id = "3",
                UserName = "admin@plathe.nl",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            }, "wachtwoord");

            rolemanager.Create(new IdentityRole("manager"));
            rolemanager.Create(new IdentityRole("cassiere"));
            rolemanager.Create(new IdentityRole("admin"));

            // assign roles to users
            usermanager.AddToRole("1", "manager");
            usermanager.AddToRole("2", "cassiere");
            usermanager.AddToRole("3", "admin");

            var genres = new List<Genre>
            {
                new Genre
                {
                    GenreId = 1,
                    Name = "Actie"
                },
                new Genre
                {
                    GenreId = 2,
                    Name = "Animatie"
                },
                new Genre
                {
                    GenreId = 3,
                    Name = "Avontuur"
                },
                new Genre
                {
                    GenreId = 4,
                    Name = "Comedy"
                },
                new Genre
                {
                    GenreId = 5,
                    Name = "Fantasy",
                },
                new Genre
                {
                    GenreId = 6,
                    Name = "Kinderfilm",
                },
                new Genre
                {
                    GenreId = 7,
                    Name = "Nederlands",
                },
                new Genre
                {
                    GenreId = 8,
                    Name = "Thriller",
                }
            };
            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            /**
             * Add shows
             */
            var movies = new List<Movie>
            {
                new Movie
                {
                    MovieId = 1,
                    Title = "Avengers: Age of Ultron",
                    Language = "EN",
                    Duration = 141,
                    MinimumAge = 12,
                    Description =
                        "Wanneer een vredesprogramma van Tony Stark verschrikkelijk verkeerd gaat moet het team van superhelden de strijd aangaan met de kwade en alles vernietigende Ultron. Marvel Studios presenteert Avengers: Age of Ultron, het epische vervolg op de grootste superheldenfilm aller tijden. Als Tony Stark probeert om een slapend vredesinitiatief nieuw leven in te blazen, gaat het goed mis en de machtigste helden van de aarde, waaronder Iron Man, Captain America, Thor, The Incredible Hulk, Black Widow en Hawkeye worden tot het uiterste op de proef gesteld als het lot van de aarde in hun handen ligt. Als de kwaadaardige Ultron verschijnt, is het aan The Avengers om zijn verschrikkelijke plannen te stoppen en al snel zorgen ongemakkelijke bondgenootschappen en onverwachte acties voor een uniek episch en wereldwijd avontuur.",
                    ThreeDimensional = true,
                    Image =
                        "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/Avengersageofultron670x945.jpg",
                    RatingViolence = true,
                    RatingFear = true,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false,
                    Director = "Joss Whedon",
                    MainCharacters = "Robert Downey Jr; Chris Evans; Mark Ruffalo; Scarlett Johansson",
                    LinkToImdb = "http://www.imdb.com/title/tt2395427/?ref_=nv_sr_1",
                    LinkToTrailer = "https://www.youtube.com/watch?v=rD8lWtcgeyg",
                    LinkToWebsite = "http://marvel.com/movies/movie/193/avengers_age_of_ultron",
                    PlaysUntill = new DateTime(2015, 10, 01, 10, 1, 59),
                    GenreId = 1
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "De Masters",
                    Language = "NL",
                    Duration = 96,
                    MinimumAge = 12,
                    Description =
                        "Wat als één van je maten met jouw tekst een hit scoort en je daarna niet meer kent? In de hilarische komedie De Masters overkomt het Aziz (Mimoun Oaissa). Zijn rapcrew De Masters weet nooit door te breken en jaren later hebben Aziz en zijn maat Marco (Ruben van der Meer) een slecht betaald baantje in een fabriek. Marco gokt liever in het casino dan op een comeback, maar Aziz is nog altijd van plan om een hit te scoren. Als zelfs zijn zoontje niet meer in hem gelooft en zijn ex hem de voogdij dreigt te ontnemen, is het alles of niets. De Masters moeten terugkomen! Het valt niet mee om de mannen enthousiast te krijgen; Lloyd (Willie Wartaal) is een paranoïde pizzabezorger en de brave Donny (Guido Pollemans) zit zwaar onder de plak bij zijn dominante vrouw. Maar Aziz krijgt ze zo ver om nog één keer met hem het podium op te gaan. Voor een hit gaan ze ver. Heel ver.",
                    ThreeDimensional = false,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/demastersp1v2.jpg",
                    RatingViolence = false,
                    RatingFear = false,
                    RatingSex = true,
                    RatingDiscrimination = true,
                    RatingDrugs = false,
                    RatingLanguage = true,
                    Director = "Ruud Schuurman",
                    MainCharacters = "Mimoun Oaissa; Ruben van der Meer, Willie Wartaal",
                    LinkToImdb = "http://www.imdb.com/title/tt4015478/",
                    LinkToTrailer = "https://www.youtube.com/watch?v=sxWH0SYcWrs",
                    LinkToWebsite = "http://www.demastersdefilm.nl/",
                    PlaysUntill = new DateTime(2015, 10, 01, 10, 1, 59),
                    GenreId = 7
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Fast and Furious 7",
                    Language = "EN",
                    Duration = 137,
                    MinimumAge = 12,
                    Description =
                        "Vin Diesel, Paul Walker en Dwayne Johnson zijn opnieuw samen te zien in de hoofdrollen van Fast & Furious 7. James Wan regisseert dit nieuwe deel uit de succesvolle filmreeks waarin ook Michelle Rodriguez, Jordana Brewster, Tyrese Gibson, Chris ´Ludacris´ Bridges, Elsa Patakay en Lucas Black terugkeren. De cast wordt versterkt door internationale sterren Jason Statham, Djimon Hounsou, Tony Jaa, Ronda Rousey en Kurt Russell. Neal H. Moritz, Vin Diesel en Michael Fottrel keren terug als producenten van deze film geschreven door Chris Morgan.",
                    ThreeDimensional = false,
                    Image =
                        "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/fast_amp_furious_7_02037619_ps_3_s-high.jpg",
                    RatingViolence = true,
                    RatingFear = false,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = true,
                    Director = "James Wan",
                    MainCharacters = "Vin Diesel; Paul Walker; Dwayne Johnson; Jason Statham; Michelle Rodriguez",
                    LinkToImdb = "http://www.imdb.com/title/tt2820852/?ref_=nv_sr_1",
                    LinkToTrailer = "https://www.youtube.com/watch?v=Skpu5HaVkOc",
                    LinkToWebsite = "http://universalshowtimes.com/nl/fast-and-furious-7/",
                    PlaysUntill = new DateTime(2015, 10, 01, 10, 1, 59),
                    GenreId = 1
                },
                new Movie
                {
                    MovieId = 4,
                    Title = "Get Hard",
                    Language = "EN",
                    Duration = 100,
                    MinimumAge = 12,
                    Description =
                        "Als de steenrijke hedgefondsmanager James King (Will Ferrell) wegens fraude wordt veroordeeld tot een lange gevangenisstraf in San Quentin, krijgt hij van de rechter dertig dagen de tijd om zijn zaakjes te regelen. Wanhopig wendt hij zich tot Darnell Lewis (Kevin Hart) om hem voor te bereiden op het leven achter de tralies. Maar James blijkt een vergissing gemaakt te hebben, Darnell is namelijk de hardwerkende eigenaar van een eigen bedrijfje, die nog nooit een bekeuring heeft gehad, laat staan een gevangenisstraf. Samen doen de twee mannen alles om James te harden voor het gevangenisleven en ontdekken al doende dat ze van heel veel dingen een verkeerd beeld hebben, ook van elkaar.",
                    ThreeDimensional = false,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/gethardposter1.jpg",
                    RatingViolence = false,
                    RatingFear = true,
                    RatingSex = true,
                    RatingDiscrimination = true,
                    RatingDrugs = false,
                    RatingLanguage = true,
                    Director = "Etan Cohen",
                    MainCharacters = "Will Ferrell; Kevin Hart",
                    LinkToImdb = "http://www.imdb.com/title/tt2561572/?ref_=nv_sr_1",
                    LinkToTrailer = "https://www.youtube.com/watch?v=lEqrpuU9fYI",
                    LinkToWebsite = "http://gethardmovie.com/",
                    PlaysUntill = new DateTime(2015, 10, 01, 10, 1, 59),
                    GenreId = 4
                },
                new Movie
                {
                    MovieId = 5,
                    Title = "Mad Max: Fury Road",
                    Language = "EN",
                    Duration = 120,
                    MinimumAge = 16,
                    Description =
                        "Regisseur George Miller, bedenker van het postapocalyptische genre en meesterbrein achter de legendarische Mad Max-cyclus, komt met “Mad Max: Fury Road” Dit verhaal neemt ons mee terug naar de wereld van de Road Warrior, Max Rockatansky. Achtervolgd door zijn turbulente verleden, is Mad Max ervan overtuigd dat hij alleen kan overleven als hij in zijn eentje opereert. Toch komt hij in contact met een groep die in een oorlogsvoertuig, bestuurd door de imperator Furiosa, door het ‘Wasteland’ trekt. De groep is op de vlucht voor de tiran Immortan Joe, van wie iets onvervangbaars is gestolen. De woedende krijgsheer stuurt al zijn bendes achter de rebellen aan, wat uitmondt in een meedogenloze, bloedstollende Road War.",
                    ThreeDimensional = true,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/madmaxfuryroadp4.jpg",
                    RatingViolence = true,
                    RatingFear = false,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false,
                    Director = "George Miller",
                    MainCharacters = "Tom Hardy; Nicholas Hoult; Charlize Theron",
                    LinkToImdb = "http://www.imdb.com/title/tt1392190/?ref_=nv_sr_1",
                    LinkToTrailer = "https://www.youtube.com/watch?v=hEJnMQG9ev8",
                    LinkToWebsite = "http://www.madmaxmovie.com/",
                    PlaysUntill = new DateTime(2015, 10, 01, 10, 1, 59),
                    GenreId = 8
                },
                new Movie
                {
                    MovieId = 6,
                    Title = "Shaun het Schaap: De Film",
                    Language = "NL",
                    Duration = 85,
                    MinimumAge = 0,
                    Description =
                        "Shaun het Schaap maakte zijn eerste optreden in de Oscarwinnende korte Wallace & Gromit-film A Close Shave (1995). Shaun is 's werelds bekendste schaap en weet televisiekijkers in al meer dan 170 landen te vermaken. Shauns kattenkwaad zorgt er dit keer voor dat de boer wordt weggevoerd van de boerderij. Shaun en Bitzer moeten samen met de kudde de grote stad trotseren om hem te redden. Het begin van een episch avontuur voor het grote scherm.",
                    ThreeDimensional = false,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/shaunhetschaapnlp2.jpg",
                    RatingViolence = false,
                    RatingFear = false,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false,
                    Director = "Richard Starzak; Mark Burton",
                    MainCharacters = " Justin Fletcher; John Sparkes; Omid Djalili",
                    LinkToImdb = "http://www.imdb.com/title/tt2872750/?ref_=nv_sr_1",
                    LinkToTrailer = "https://www.youtube.com/watch?v=tQvwiOWpj7o",
                    LinkToWebsite = "http://shaunthesheep.com/",
                    PlaysUntill = new DateTime(2015, 10, 01, 10, 1, 59),
                    GenreId = 6
                },
                new Movie
                {
                    MovieId = 7,
                    Title = "Home",
                    Language = "NL",
                    Duration = 137,
                    MinimumAge = 12,
                    Description =
                        "De Moefs veroveren onze planeet. Het vindingrijke meisje Tip weet echter uit hun handen te blijven en ontmoet Oh, een verbannen Moef. Samen proberen ze de aarde te redden. Als de aarde wordt veroverd door de Moefs, een buitenaards ras dat op zoek is naar een nieuwe thuisplaneet, worden eerst alle mensen naar een andere locatie gebracht. Maar terwijl de Moefs de planeet reorganiseren, slaagt het vindingrijke meisje Tip erin om uit handen van de Moefs te blijven en krijgt ze gezelschap van Oh, een verbannen Moef. Tijdens hun bijzondere avontuur beseffen de twee vluchtelingen dat er meer op het spel staat dan alleen de verhoudingen in het universum. ",
                    ThreeDimensional = true,
                    Image = "https://media.pathe.nl/nocropthumb/180x254/gfx_content/posters/homenlposter2.jpg",
                    RatingViolence = false,
                    RatingFear = true,
                    RatingSex = false,
                    RatingDiscrimination = false,
                    RatingDrugs = false,
                    RatingLanguage = false,
                    Director = "Tim Johnson",
                    MainCharacters = " Jim Parsons; Rihanna; Steve Martin",
                    LinkToImdb = "http://www.imdb.com/title/tt2224026/?ref_=nv_sr_1",
                    LinkToTrailer = "https://www.youtube.com/watch?v=W6Bd3TWpeig",
                    LinkToWebsite = "http://www.dreamworks.com/home/",
                    PlaysUntill = new DateTime(2015, 10, 01, 10, 1, 59),
                    GenreId = 6
                }
            };
            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();

            /**
             * Add rooms
             */

            var rooms = new List<Room>
            {
                new Room
                {
                    RoomId = 1,
                    RoomName = "Zaal 1",
                    WheelchairAccess = true,
                    ThreeDimensional = true,
                    CountRows = 8,
                    CountSeats = 15
                },
                new Room
                {
                    RoomId = 2,
                    RoomName = "Zaal 2",
                    WheelchairAccess = true,
                    ThreeDimensional = true,
                    CountRows = 8,
                    CountSeats = 15
                },
                new Room
                {
                    RoomId = 3,
                    RoomName = "Zaal 3",
                    WheelchairAccess = true,
                    ThreeDimensional = false,
                    CountRows = 8,
                    CountSeats = 15
                },
                new Room
                {
                    RoomId = 4,
                    RoomName = "Zaal 4",
                    WheelchairAccess = true,
                    ThreeDimensional = false,
                    CountRows = 6,
                    CountSeats = 10
                },
                new Room
                {
                    RoomId = 5,
                    RoomName = "Zaal 5",
                    WheelchairAccess = false,
                    ThreeDimensional = false,
                    CountRows = 4,
                    CountSeats = 15
                },
                new Room
                {
                    RoomId = 6,
                    RoomName = "Zaal 6",
                    WheelchairAccess = false,
                    ThreeDimensional = false,
                    CountRows = 4,
                    CountSeats = 15
                }
            };
            rooms.ForEach(s => context.Rooms.Add(s));
            context.SaveChanges();

            /**
             * Add rows and seats for room 1 t/m 3 
             */

            var rows = new List<Row>();
            var seats = new List<Seat>();
            var rowCount = 1;
            var seatCount = 1;

            foreach (Room room in rooms)
            {
                for (int rowId = 1; rowId <= room.CountRows; rowId++)
                {
                    rows.Add(new Row
                    {
                        RowId = rowCount,
                        RoomId = room.RoomId
                    });

                    for (int seatId = 1; seatId <= room.CountSeats; seatId++)
                    {
                        seats.Add(new Seat
                        {
                            SeatId = seatCount++,
                            RowId = rowCount,
                            WheelChairSeat = false,
                            PrioritySeat = false
                        });
                    }

                    rowCount++;
                }
            }

            rows.ForEach(s => context.Rows.Add(s));
            context.SaveChanges();
            seats.ForEach(s => context.Seats.Add(s));
            context.SaveChanges();


            /**
             * Add shows
             */
            var shows = new List<Show>
            {

                // vandaag
                new Show
                {
                    ShowId = 1,
                    MovieId = 1,
                    RoomId = 1,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(18).AddMinutes(30),
                    ThreeDimensional = true
                },
                new Show
                {
                    ShowId = 2,
                    MovieId = 2,
                    RoomId = 2,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(19),
                    ThreeDimensional = false
                },
                new Show
                {
                    ShowId = 3,
                    MovieId = 3,
                    RoomId = 3,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(19).AddMinutes(30),
                    ThreeDimensional = true
                },
                new Show
                {
                    ShowId = 4,
                    MovieId = 4,
                    RoomId = 4,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddHours(20),
                    ThreeDimensional = false
                },
                new Show
                {
                    ShowId = 5,
                    MovieId = 5,
                    RoomId = 5,
                    Subtitle = "NL",
                    StartingTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    ThreeDimensional = false
                },
                new Show
                {
                    ShowId = 6,
                    MovieId = 6,
                    RoomId = 6,
                    Subtitle = "FR",
                    StartingTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    ThreeDimensional = false
                },

                // morgen
                new Show
                {
                    ShowId = 7,
                    MovieId = 1,
                    RoomId = 1,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddDays(1).AddHours(18).AddMinutes(30),
                    ThreeDimensional = true
                },
                new Show
                {
                    ShowId = 8,
                    MovieId = 2,
                    RoomId = 2,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddDays(1).AddHours(19),
                    ThreeDimensional = false
                },
                new Show
                {
                    ShowId = 9,
                    MovieId = 3,
                    RoomId = 3,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddDays(1).AddHours(19).AddMinutes(30),
                    ThreeDimensional = true
                },
                new Show
                {
                    ShowId = 10,
                    MovieId = 4,
                    RoomId = 4,
                    Subtitle = "EN",
                    StartingTime = DateTime.Today.AddDays(1).AddHours(20),
                    ThreeDimensional = false
                },
                new Show
                {
                    ShowId = 11,
                    MovieId = 5,
                    RoomId = 5,
                    Subtitle = "NL",
                    StartingTime = DateTime.Today.AddDays(1).AddHours(20).AddMinutes(30),
                    ThreeDimensional = false
                },
                new Show
                {
                    ShowId = 12,
                    MovieId = 6,
                    RoomId = 6,
                    Subtitle = "FR",
                    StartingTime = DateTime.Today.AddDays(1).AddHours(20).AddMinutes(30),
                    ThreeDimensional = false
                },

            };
            shows.ForEach(s => context.Shows.Add(s));
            context.SaveChanges();


            /**
             * Add reservations
             */
            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    ReservationId = 1,
                    UniqueCode = "1234",
                    CreateOn = DateTime.Today.AddHours(20).AddMinutes(00),
                    PriceTotal = (decimal) 15.00,
                    Payed = true,
                    PayedOn = DateTime.Now
                },
                new Reservation
                {
                    ReservationId = 2,
                    UniqueCode = "ABC123",
                    CreateOn = DateTime.Today.AddHours(20).AddMinutes(10),
                    PriceTotal = (decimal) 10.00,
                    Payed = true,
                    PayedOn = DateTime.Now
                }
            };
            reservations.ForEach(s => context.Reservations.Add(s));
            context.SaveChanges();

            /**
             * Add tickets
             */
            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    ShowId = 1,
                    ReservationId = reservations.Single(i => i.ReservationId == 1).ReservationId,
                    SeatId = 33,
                    Price = (decimal) 8.50,
                    PopcornTime = false,
                    UniqueCode = "".CreateRandomString(),
                    Options = "options",
                },
                new Ticket
                {
                    ShowId = 1,
                    ReservationId = reservations.Single(i => i.ReservationId == 1).ReservationId,
                    SeatId = 34,
                    Price = (decimal) 8.50,
                    PopcornTime = false,
                    UniqueCode = "".CreateRandomString(),
                    Options = "options",
                },
                new Ticket
                {
                    ShowId = 1,
                    ReservationId = reservations.Single(i => i.ReservationId == 1).ReservationId,
                    SeatId = 35,
                    Price = (decimal) 8.50,
                    PopcornTime = false,
                    UniqueCode = "".CreateRandomString(),
                    Options = "options",
                },
                new Ticket
                {
                    ShowId = 1,
                    ReservationId = reservations.Single(i => i.ReservationId == 1).ReservationId,
                    SeatId = 83,
                    Price = (decimal) 8.50,
                    PopcornTime = false,
                    UniqueCode = "".CreateRandomString(),
                    Options = "options",
                },
                new Ticket
                {
                    ShowId = 1,
                    ReservationId = reservations.Single(i => i.ReservationId == 1).ReservationId,
                    SeatId = 84,
                    Price = (decimal) 8.50,
                    PopcornTime = false,
                    UniqueCode = "".CreateRandomString(),
                    Options = "options",
                }
            };

            tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();

            //add LostItems door Mieke

            var lostitems = new List<LostItem>
            {
                new LostItem
                {
                    LostItemId = 1,
                    Name = "Paarse krokodil",
                    Location = "Zaal 1",
                    Description = "Volledig opgeblazen paarse krokodil",
                    TimeFound = DateTime.Today.AddHours(20).AddMinutes(10),
                    Collected = false
                },
                new LostItem
                {
                    LostItemId = 2,
                    Name = "Groene krokodil",
                    Location = "Zaal 4",
                    Description = "Volledig opgeblazen groene krokodil",
                    TimeFound = DateTime.Today.AddHours(20).AddMinutes(10),
                    Collected = true
                },
            };

            lostitems.ForEach(s => context.LostItems.Add(s));
            context.SaveChanges();
        }
    }
}