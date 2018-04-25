using System;
using System.IO;
using NUnit.Framework;
using TheUnitGallery.Controllers;
using TheUnitGallery.Models.Interfaces;
using System.Web.Mvc;
using Moq;
using System.Linq;
using TheUnitGallery.Models;
using TheUnitGallery.ViewModels;

namespace TheUnitGallery.UnitTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        Mock<IPageRepository> pageMock = new Mock<IPageRepository>();
        Mock<IGenreRepository> genreMock = new Mock<IGenreRepository>();
        Mock<IMediumRepository> mediumMock = new Mock<IMediumRepository>();
        Mock<IArtistRepository> artistMock = new Mock<IArtistRepository>();

        [SetUp]
        public void SetUp()
        {
            pageMock.Setup(pm => pm.Pages).Returns(new Page[]
            {
                new Page {Identifier = "homepage", Title = "Title Home", },
                new Page {Identifier = "Account Page", Title = "Title Account", },
                new Page {Identifier = "List Page", Title = "Title List", },
            }.AsQueryable());

            genreMock.Setup(pm => pm.Genres).Returns(new Genre[]
            {
                new Genre {Id = 1, Name = "Genre1", VisibleFrontEnd = true},
                new Genre {Id = 2, Name = "Genre2", VisibleFrontEnd = true},
                new Genre {Id = 3, Name = "Genre3", VisibleFrontEnd = true},
            }.AsQueryable());

            mediumMock.Setup(pm => pm.Mediums).Returns(new Medium[]
            {
                new Medium {Id = 1, Name = "Medium1", VisibleFrontEnd = true},
                new Medium {Id = 2, Name = "Medium2", VisibleFrontEnd = true},
                new Medium {Id = 3, Name = "Medium3", VisibleFrontEnd = true},
            }.AsQueryable());

            artistMock.Setup(pm => pm.Artists).Returns(new Artist[]
            {
                new Artist {Id = 1, FirstName = "Ben", LastName = "Staley", Alias = "BS"},
                new Artist {Id = 2, FirstName = "Sally", LastName = "Jones", Alias = "SJ"},
                new Artist {Id = 3, FirstName = "Criag", LastName = "Smith", Alias = "CS"},
            }.AsQueryable());

            var controller = new HomeController(pageMock.Object, genreMock.Object, mediumMock.Object, artistMock.Object);
        }

        [Test]
        public void Index_Returns_ViewResult()
        {
            //Arrange
            var controller = new HomeController(pageMock.Object, genreMock.Object, mediumMock.Object, artistMock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Index_View_Contains_HomepageViewModel()
        {
            var controller = new HomeController(pageMock.Object, genreMock.Object, mediumMock.Object, artistMock.Object);

            //Act
            var result = (HomepageViewModel)controller.Index().Model;

            //Assert
            Assert.IsInstanceOf<HomepageViewModel>(result);
        }
    }
}
