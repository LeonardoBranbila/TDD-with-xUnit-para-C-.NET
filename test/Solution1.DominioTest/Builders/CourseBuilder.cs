using static Solution1.Dominio.Courses.TestCourse;


namespace TestSolution.DominioTest.Builders
{
    class CourseBuilder
    {
        private string _name = "Informatic";
        private float _workload = (float)80;
        private TargetAudience _targetaudience = TargetAudience.Student;
        private float _value = (float)250;
        private string _description = "Description";
        public static CourseBuilder New()
        {
            return new CourseBuilder();
        }

        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        public CourseBuilder WithWorkload(float workload)
        {
            _workload = workload;
            return this;
        }
        public CourseBuilder WithTargetAudience(TargetAudience targetaudience)
        {
            _targetaudience = targetaudience;
            return this;
        }
        public CourseBuilder WithValue(float value)
        {
            _value = value;
            return this;
        }
        public CourseBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public Course Build()
        {
            return new Course(_name, _workload, _targetaudience, _value, _description);
        }
    }

}
