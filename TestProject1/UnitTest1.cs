using GestaoEscolar_M3S01.Api.SubjectRating.DTO;
using GestaoEscolar_M3S01.Api.SubjectRating.Repository;
using GestaoEscolar_M3S01.Shared.Context;
using Moq;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldThrowOnNegativeMark()
    {
        // ARRANGE
        var mock = new Mock<SchoolContext>(null);
        mock.Setup(p => p.Add(It.IsAny<object>()));
        var mark = new SubjectRatingRequest()
        {
            ReportId = 0,
            Mark = -1,
            SubjectId = 0,
        };
        // ACT
        var sut = new SubjectRatingRepository(mock.Object);
        // ASSERT
        Assert.That(async () => await sut.AddSubjectReport(mark), 
            Throws.TypeOf<ArgumentException>());
    }
    
    [Test]
    public void ShouldThrowOnPositiveMark()
    {
        // ARRANGE
        var mock = new Mock<SchoolContext>(null);
        mock.Setup(p => p.Add(It.IsAny<object>()));
        var mark = new SubjectRatingRequest()
        {
            ReportId = 0,
            Mark = 1,
            SubjectId = 0,
        };
        // ACT
        var sut = new SubjectRatingRepository(mock.Object);
        // ASSERT
        Assert.That(async () => await sut.AddSubjectReport(mark), 
            Throws.TypeOf<ArgumentException>());
    }
}