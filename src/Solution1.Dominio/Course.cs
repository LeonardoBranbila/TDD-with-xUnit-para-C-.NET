namespace Solution1.Dominio.Courses     
{

    public partial class TestCourse
    {
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
