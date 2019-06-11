using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.CodeGen.NSwag
{
    [CakeAliasCategory("NSwag")]
    public static class NSwagAliases
    {
        private static NSwagSources Runner;

        [CakePropertyAlias]
        public static NSwagSources NSwag(this ICakeContext context)
        {
            if (Runner == null)
            {
                Runner = new NSwagSources(context);
            }
            return Runner;
        }

    }
}
