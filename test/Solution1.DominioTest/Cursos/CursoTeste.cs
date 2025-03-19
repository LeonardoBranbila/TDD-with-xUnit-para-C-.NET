using ExpectedObjects;
using Solution1.DominioTest._Util;
using Xunit.Abstractions;


namespace Solution1.DominioTest.Courses
{

    public class TestCourse
    {
        private readonly ITestOutputHelper _output;
        private string _name;
        private float _workload;
        private TargetAudience _TargetAudience;
        private float _value;

        public TestCourse(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Constructor beeing executed");


            _name = "Informatic";
            _workload = (float)80;
            _TargetAudience = TargetAudience.Estudante;
            _value = (float)250;

        }


        [Fact]
        //Setup of the test
        public void MustCreateCourse()
        {
            var CourseEsperado = new
            {
                name = "Informatic",
                workload = (float)80,
                TargetAudience = TargetAudience.Estudante,
                value = 250
            };

            var Course = new Course(CourseEsperado.name, CourseEsperado.workload,
                CourseEsperado.TargetAudience, CourseEsperado.value) { };


            CourseEsperado.ToExpectedObject().ShouldMatch(Course);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CoursesMustNotHaveAnInvalidName(string nameInvalido)
        {

            //The Message here tests whether the exception that came is the exception that we defined below,
            // to see if the error it gave is really the error that we are testing in the method and not another one.
            Assert.Throws<ArgumentException>(() => new Course(nameInvalido, _workload,
                _TargetAudience, _value)).WithMessage("Invalid name");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void MustNotHaveWorkloadLessThanOne(float workload)
        {
          Assert.Throws<ArgumentException>(() => new Course(_name, workload,
                _TargetAudience, _value)).WithMessage("Invalid workload");
        }


        [Theory]
        [InlineData(-1)]
        public void MustNotHaveAValueLessThanOne(float value)
        {
           
           Assert.Throws<ArgumentException>(() => new Course(_name, _workload,
                _TargetAudience, value)).WithMessage("Invalid value");
           
        }



        public enum TargetAudience
        {
            Estudante,
            Universitario,
            Empregado,
            Empreendedor
        }


        public class Course
        {
            public string name { get; private set; }
            public float workload { get; private set; }
            public TargetAudience TargetAudience { get; private set; }
            public float value { get; private set; }

            public Course(string name, float workload, TargetAudience TargetAudience, float value)
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
            }
        }
    }
}
