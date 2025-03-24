using Bogus;
using ExpectedObjects;
using Xunit.Abstractions;
using TestSolution.DominioTest.Builders;
using static Solution1.Dominio.Courses.TestCourse;



namespace Solution1.DominioTest.Courses     
{

    public partial class TestCourse : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private string _name;
        private float _workload;
        private TargetAudience _TargetAudience;
        private float _value;
        private string _description;

        public TestCourse(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Constructor beeing executed");
            var faker = new Faker();


            _name = faker.Person.FullName;
            _workload = faker.Random.Float(50, 200);
            _TargetAudience = TargetAudience.Student;
            _value = faker.Random.Float(100, 1000);
            _description = faker.Lorem.Paragraph();
        }
        public void Dispose()
        {
            _output.WriteLine("Dispose beeing executed");
        }

        [Fact]
        //Setup of the test
        public void MustCreateCourse()
        {
            var expectedCourse = new
            {
                name = _name,
                workload = _workload,
                targetaudience = _TargetAudience,
                value = _value,
                description = _description
            };

            var Course = new Course(expectedCourse.name, expectedCourse.workload,
                expectedCourse.targetaudience, expectedCourse.value, expectedCourse.description);


            expectedCourse.ToExpectedObject().ShouldMatch(Course);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CoursesMustNotHaveAnInvalidName(string invalidName)
        {

            //The Message here tests whether the exception that came is the exception that we defined below,
            // to see if the error it gave is really the error that we are testing in the method and not another one.
            Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithName(invalidName).Build());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void MustNotHaveWorkloadLessThanOne(float invalidWorkload)
        {
          Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithWorkload(invalidWorkload).Build());
        }


        [Theory]
        [InlineData(-1)]
        public void MustNotHaveAValueLessThanOne(float invalidValue)
        {
           
           Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithWorkload(invalidValue).Build());
           
        }
    }
}
