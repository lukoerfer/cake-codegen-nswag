# Cake NSwag Addin
Cake Addin for code generation from OpenAPI specifications via [NSwag](https://github.com/RicoSuter/NSwag)

## Motivation

## Installation
The addin is available on NuGet, so it can simply be registered in your `build.cake` file via the `#addin` preprocessor directive:

    #addin nuget:?package=Cake.CodeGen.OpenAPI&version=1.0.0

## Usage
When the addin is registered, it adds an extension property called `NSwag` to the context of the `build.cake` script. This property provides various methods to define an OpenAPI specification source. Using the returned object, clients for C# and TypeScript can be generated as well as ASP.NET controller templates:

    NSwag.FromYamlSpecification("swagger.yaml")                    // or FromJsonSpecification("swagger.json")
        .GenerateCSharpClient("Client.Generated.cs")
        .GenerateTypeScriptClient("client-generated.ts", new TypeScriptClientGeneratorSettings() {
            ClassName = "MyGeneratedClient"
        })
        .GenerateCSharpController("Controller.Generated.cs");

For details on the optional generator settings check out the NSwag documentation. Multiple invocations of the same code generator (e.g. `GenerateCSharpClient`) with different settings and different output files are possible.

Beside using a local file with an OpenAPI specification, a remote URL can be accessed by passing an `URI` to the source methods `FromYamlSpecification` and `FromJsonSpecification`. Please note, that file URIs cannot be passed via those methods, only http(s) URLs are allowed.

## License
The software is licensed under the [MIT license](https://github.com/lukoerfer/cake-codegen-nswag/blob/master/LICENSE).
