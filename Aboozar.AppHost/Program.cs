var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aboozar>("aboozar");

builder.Build().Run();
