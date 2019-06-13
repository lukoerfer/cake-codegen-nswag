var target = Argument("target", "Default");

Task("Test")
	.Does(() =>
{
	NSwag.FromYamlSpec("petstore.yaml").GenerateCSharpClient("Client.Generated.cs");
});

RunTarget(target);