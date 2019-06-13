using System;

using Cake.Common.IO;
using Cake.Core;
using Cake.Core.IO;

using NSwag;

namespace Cake.CodeGen.NSwag
{
    public class NSwagSources
    {
        private readonly ICakeContext Context;

        public NSwagSources(ICakeContext context)
        {
            Context = context;
        }

        public NSwagRunner FromJsonSpecification(FilePath specification)
        {
            string path = Context.MakeAbsolute(specification).FullPath;
            OpenApiDocument document = OpenApiDocument.FromFileAsync(path).Result;
            return new NSwagRunner(Context, document);
        }

        public NSwagRunner FromJsonSpecification(Uri specification)
        {
            OpenApiDocument document = OpenApiDocument.FromUrlAsync(specification.ToString()).Result;
            return new NSwagRunner(Context, document);
        }

        public NSwagRunner FromYamlSpecification(FilePath specification)
        {
            string path = Context.MakeAbsolute(specification).FullPath;
            OpenApiDocument document = OpenApiYamlDocument.FromFileAsync(path).Result;
            return new NSwagRunner(Context, document);
        }

        public NSwagRunner FromYamlSpecification(Uri specification)
        {
            OpenApiDocument document = OpenApiYamlDocument.FromUrlAsync(specification.ToString()).Result;
            return new NSwagRunner(Context, document);
        }

    }
}
