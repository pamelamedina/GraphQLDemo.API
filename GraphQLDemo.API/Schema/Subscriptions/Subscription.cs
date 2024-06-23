using GraphQLDemo.API.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Subscriptions
{
	public class Subscription
	{
		[Subscribe]
		public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

		

	}
}
