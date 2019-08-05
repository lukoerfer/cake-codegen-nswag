using System;
using System.IO;

using Cake.Core;
using Cake.Core.IO;
using Cake.Common.IO;

using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.TypeScript;

namespace Cake.CodeGen.NSwag
{
    /// <summary>
    /// 
    /// </summary>
    public class NSwagRunner
    {
        private readonly ICakeContext Context;

        private readonly OpenApiDocument Document;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="document"></param>
        public NSwagRunner(ICakeContext context, OpenApiDocument document)
        {
            Context = context;
            Document = document;
        }

        /// <summary>
        /// Generates a 
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public NSwagRunner GenerateCSharpClient(FilePath outputFile, Action<CSharpClientGeneratorSettings> handler)
        {
            var settings = new CSharpClientGeneratorSettings();
            handler?.Invoke(settings);
            return GenerateCSharpClient(outputFile, settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public NSwagRunner GenerateCSharpClient(FilePath outputFile, CSharpClientGeneratorSettings settings = null)
        {
            settings = settings ?? new CSharpClientGeneratorSettings();
            var generator = new CSharpClientGenerator(Document, settings);
            WriteToFile(outputFile, generator.GenerateFile());
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public NSwagRunner GenerateTypeScriptClient(FilePath outputFile, Action<TypeScriptClientGeneratorSettings> handler)
        {
            var settings = new TypeScriptClientGeneratorSettings();
            handler?.Invoke(settings);
            return GenerateTypeScriptClient(outputFile, settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public NSwagRunner GenerateTypeScriptClient(FilePath outputFile, TypeScriptClientGeneratorSettings settings = null)
        {
            settings = settings ?? new TypeScriptClientGeneratorSettings();
            var generator = new TypeScriptClientGenerator(Document, settings);
            WriteToFile(outputFile, generator.GenerateFile());
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public NSwagRunner GenerateCSharpController(FilePath outputFile, Action<CSharpControllerGeneratorSettings> handler)
        {
            var settings = new CSharpControllerGeneratorSettings();
            handler?.Invoke(settings);
            return GenerateCSharpController(outputFile, settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public NSwagRunner GenerateCSharpController(FilePath outputFile, CSharpControllerGeneratorSettings settings = null)
        {
            settings = settings ?? new CSharpControllerGeneratorSettings();
            var generator = new CSharpControllerGenerator(Document, settings);
            WriteToFile(outputFile, generator.GenerateFile());
            return this;
        }

        private void WriteToFile(FilePath file, string content)
        {
            DirectoryPath directory = file.GetDirectory();
            if (!string.IsNullOrWhiteSpace(directory.FullPath))
            {
                Context.EnsureDirectoryExists(directory);
            }
            using (var writer = new StreamWriter(Context.FileSystem.GetFile(file).OpenWrite()))
            {
                writer.Write(content);
            }
        }

    }
}
