using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Queries;
using GraphQLDemo.API.Subscriptions;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services
		  .AddGraphQLServer()
		  .AddQueryType<Query>()
		  .AddMutationType<Mutation>()
		  .AddSubscriptionType<Subscription>()		
		  .AddInMemorySubscriptions();

		


		var app = builder.Build();

		//app.MapGet("/", () => "Hello World!");



		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		
		app.UseRouting();
		app.UseWebSockets();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapGraphQL();
		});



		app.Run();
	}

	








}