using Moq;
using Ninject;
using Plathe.Domain.Abstract;
using Plathe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Plathe.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new List<Movie> {
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
            });
            kernel.Bind<IMovieRepository>().ToConstant(mock.Object);
        }
    }
}