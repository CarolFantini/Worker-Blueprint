using Worker.Utils;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.InfraInjection();

builder.Services.AddHostedService<Worker_Blueprint.Worker>();

var host = builder.Build();
host.Run();
