#addin nuget:?package=NSwag.Core&loaddependencies=true
#addin nuget:?package=NSwag.CodeGeneration.CSharp&loaddependencies=true
#addin nuget:?package=NSwag.CodeGeneration.TypeScript&loaddependencies=true
#addin nuget:?package=NSwag.Core.Yaml&loaddependencies=true
#r "src\Cake.CodeGen.NSwag\bin\Debug\netstandard2.0\Cake.CodeGen.NSwag.dll"

var target = Argument("target", "Default");

Task("Test")
	.Does(() =>
{
	NSwag.FromYamlSpec("petstore.yaml").GenerateCSharpClient("Client.Generated.cs");
});

RunTarget(target);