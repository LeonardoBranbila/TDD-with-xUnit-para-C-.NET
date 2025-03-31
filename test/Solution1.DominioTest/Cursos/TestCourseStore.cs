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
                workload = (float)850.00,
                TargetAudience = 80,
                value = 1,
                description = "Description"

            };

            var courseRepositoryMock = new Mock<ICourseRepository>();

            var CourseStore = new CourseStore(courseRepositoryMock.Object);
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
        private readonly ICourseRepository _RepositoryCourse;

        public CourseStore(ICourseRepository RepositoryCourse)
        {
            this._RepositoryCourse = RepositoryCourse;
        }


        internal void Add(CourseDTO courseDTO)
        {
            var course = 
                new Course(courseDTO.name, courseDTO.workload, TargetAudience.Student, 
                courseDTO.value, courseDTO.description);

            _RepositoryCourse.add(course);
        }
    }

    internal class CourseDTO
    {
        public string name { get; set; }
        public float workload { get; set; }
        public int TargetAudience { get; set; }
        public int value { get; set; }
        public string description { get; set; }
    }
}
