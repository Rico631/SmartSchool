var builder = DistributedApplication.CreateBuilder(args);

var students = builder.AddProject<Projects.SmartSchool_Students>("smartschool.students");

var bff = builder.AddProject<Projects.SmartSchool_Bff>("smartschool.bff")
    .WithReference(students);

builder.AddProject<Projects.SmartSchool_Web>("smartschool.web")
    .WithReference(bff);

builder.Build().Run();
