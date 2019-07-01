using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.CodeGen.NSwag
{
    [CakeAliasCategory("NSwag")]
    public static class NSwagAliases
    {
        [CakePropertyAlias(Cache = true)]
        [CakeNamespaceImport("NSwag.CodeGeneration")]
        [CakeNamespaceImport("NSwag.CodeGeneration.Models")]
        [CakeNamespaceImport("NSwag.CodeGeneration.OperationNameGenerators")]
        [CakeNamespaceImport("NSwag.CodeGeneration.CSharp")]
        [CakeNamespaceImport("NSwag.CodeGeneration.CSharp.Models")]
        [CakeNamespaceImport("NSwag.CodeGeneration.TypeScript")]
        [CakeNamespaceImport("NSwag.CodeGeneration.TypeScript.Models")]
        public static NSwagSources NSwag(this ICakeContext context)
        {
            return new NSwagSources(context);
        }

    }
}
