using ExpectedObjects;
using ExpectedObjects.Strategies;
using Solution1.DominioTest._Util;
using TestSolution.DominioTest.Builders;
using Xunit.Abstractions;


namespace Solution1.DominioTest.Courses     
{

    public class TestCourse : IDisposable
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


            _name = "Informatic";
            _workload = (float)80;
            _TargetAudience = TargetAudience.Student;
            _value = (float)250;
            _description = "Description";

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

        public enum TargetAudience
        {
            Student,
            CollegeStudent,
            Employee,
            Entrepreneur
        }


        public class Course
        {
            public string name { get; private set; }
            public float workload { get; private set; }
            public TargetAudience TargetAudience { get; private set; }
            public float value { get; private set; }
            public string description { get; private set; }

            public Course(string name, float workload, TargetAudience TargetAudience, float value, string description)
            {
                if (string.IsNullOrEmpty(name))
                {
                    //Setting a message "type" to the exception.
                    throw new ArgumentException("Invalid name");
                }

                if (workload < 1)
                {
                    //Setting a message "type" to the exception.
                    throw new ArgumentException("Invalid workload");
                }

                if (value > 1)
                {
                    //Setting a message "type" to the exception.
                    throw new ArgumentException("Invalid value");
                }

                this.name = name;
                this.workload = workload;
                this.TargetAudience = TargetAudience;
                this.value = value;
                this.description = description;
            }
        }
    }
}
