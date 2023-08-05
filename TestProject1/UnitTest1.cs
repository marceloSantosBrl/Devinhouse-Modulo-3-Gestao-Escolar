using GestaoEscolar_M3S01.Api.SubjectRating.DTO;
using GestaoEscolar_M3S01.Api.SubjectRating.Models;
using GestaoEscolar_M3S01.Api.SubjectRating.Repository;
using GestaoEscolar_M3S01.Api.SubjectRating.Services;
using Moq;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldThrowMarkLessThanZero()
    {
        // ARRANGE
        var mock = new Mock<ISubjectRatingRepository>();
        mock.Setup(r =>
                r.AddSubjectReport(It.IsAny<SubjectRating>()))
            .ReturnsAsync(new SubjectRating());
        var sut = new SubjectRatingService(mock.Object);
        var request = new SubjectRatingRequest()
        {
            Mark = -1,
            ReportId = 0,
            SubjectId = 0,
        };
        // ASSERT
        Assert.That(() => sut.AddRating(request), 
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void ShouldNotThrowBiggerThanZero()
    {
        var mock = new Mock<ISubjectRatingRepository>();
        mock.Setup(r =>
                r.AddSubjectReport(It.IsAny<SubjectRating>()))
            .ReturnsAsync(new SubjectRating());
        var sut = new SubjectRatingService(mock.Object);
        var request = new SubjectRatingRequest()
        {
            Mark = 1,
            ReportId = 0,
            SubjectId = 0,
        };
        // ASSERT
        Assert.That(() => sut.AddRating(request), 
            Throws.Nothing);
    }
    
    
    [Test]
    public void ShouldNotThrowBetweenZeroAndTeen()
    {
        var mock = new Mock<ISubjectRatingRepository>();
        mock.Setup(r =>
                r.AddSubjectReport(It.IsAny<SubjectRating>()))
            .ReturnsAsync(new SubjectRating());
        var sut = new SubjectRatingService(mock.Object);
        var request = new SubjectRatingRequest()
        {
            Mark = 5,
            ReportId = 0,
            SubjectId = 0,
        };
        var request2 = new SubjectRatingRequest()
        {
            Mark = -1,
            ReportId = 0,
            SubjectId = 0,
        };
        var request3 = new SubjectRatingRequest()
        {
            Mark = 5,
            ReportId = 0,
            SubjectId = 0,
        };
        // ASSERT
        Assert.That(() => sut.AddRating(request), 
            Throws.Nothing);
        Assert.That(() => sut.AddRating(request2), 
            Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => sut.AddRating(request3), 
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}