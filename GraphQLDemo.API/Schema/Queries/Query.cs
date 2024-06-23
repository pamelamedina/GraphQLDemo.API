using Bogus;
using System.Reflection.Metadata.Ecma335;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        //GraphQLDeprecated("This is history ")]
        //public string Instructions() => "Smash the like button and subscribe to Pam";

        private Faker<CourseType>? _courseFaker = null;
        private Faker<StudentType>? _studentFaker = null;
        private Faker<InstructorType>? _instructorFaker = null;


        public IEnumerable<CourseType> GetCourses()
        {
            _instructorFaker = new Faker<InstructorType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Salary, f => f.Random.Double(0, 100000));

            _studentFaker = new Faker<StudentType>()
           .RuleFor(c => c.Id, f => Guid.NewGuid())
           .RuleFor(c => c.FirstName, f => f.Name.FirstName())
           .RuleFor(c => c.LastName, f => f.Name.LastName())
           .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

            _courseFaker = new Faker<CourseType>()
           .RuleFor(c => c.Id, f => Guid.NewGuid())
           .RuleFor(c => c.Name, f => f.Name.JobTitle())
           .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
           .RuleFor(c => c.Instructor, f => _instructorFaker.Generate())
           .RuleFor(c => c.Students, f => _studentFaker.Generate(3));

            return _courseFaker.Generate(5);
        }

        public async Task<CourseType> GetCoursesByIdAsync(Guid id)
        {
            CourseType? course = null;
            course = _courseFaker.Generate();
            await Task.Delay(2);
            course.Id = id;
            return course;
        }
    }
}
