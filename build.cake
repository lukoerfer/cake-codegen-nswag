var target = Argument("target", "Default");

var solution = File("./src/Cake.CodeGen.NSwag.sln");
var project = File("./src/Cake.CodeGen.NSwag/Cake.CodeGen.NSwag.csproj");

Task("Clean")
	.Does(() =>
{
	CleanDirectory("./artifacts");
	CleanDirectories("./src/**/bin");
	CleanDirectories("./src/**/obj");
});

Task("Build")
	.Does(() =>
{
	DotNetCoreBuild(solution);
});

Task("Create-Nuget")
	.IsDependentOn("Build")
	.Does(() =>
{
	DotNetCorePack(project, new DotNetCorePackSettings() {
		OutputDirectory = "./artifacts/nuget"
	});
});

Task("Publish-Nuget")
	.IsDependentOn("Create-Nuget")
	.Does(() => 
{
	var packages = GetFiles("./artifacts/nuget/*.nupkg");
	NuGetPush(packages, new NuGetPushSettings() {
		 Source = @"C:\Users\Koerfer\.nuget\packages"
	});
});

RunTarget(target);