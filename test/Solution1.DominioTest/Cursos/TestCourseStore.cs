using Moq;
using Xunit;
using static Solution1.Dominio.Courses.TestCourse;
using static TestSolution.DominioTest.Cursos.TestCourseStore;

namespace TestSolution.DominioTest.Cursos
{
    public class TestCourseStore
    {
        [Fact]
        public void HaveCreateCourse()
        {
            var courseDTO = new CourseDTO
            {
                name = "Course A",
                workload = "Description",
                TargetAudience = 80,
                value = 1,
                description = 850.00

            };

            var courseRepositoryMock = new Mock<ICourseRepository>();

            var testCourseStore = new CourseStore(courseRepositoryMock.Object);
            CourseStore.Add(courseDTO);

            courseRepositoryMock.Verify(r => r.add(It.IsAny<Course>()));

        }

    }
    public interface ICourseRepository
    {
        void add(Course course)
        {

        }
    }

    public class CourseStore
    {
        private ICourseRepository @object;

        public CourseStore(ICourseRepository @object)
        {
            this.@object = @object;
        }

        void StoreCourse(ICourseRepository courseRepository)
        {
            throw new NotImplementedException();
        }

        internal static void Add(CourseDTO courseDTO)
        {
            throw new NotImplementedException();
        }
    }

    internal class CourseDTO
    {
        public string name { get; set; }
        public string workload { get; set; }
        public int TargetAudience { get; set; }
        public int value { get; set; }
        public double description { get; set; }
    }
}
