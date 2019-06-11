﻿using System;
using System.IO;

using Cake.Core;
using Cake.Core.IO;

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
        public NSwagRunner GenerateCSharpClient(FilePath outputFile, Action<CSharpClientGeneratorSettings> handler = null)
        {
            var settings = new CSharpClientGeneratorSettings();
            handler?.Invoke(settings);
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
        public NSwagRunner GenerateTypeScriptClient(FilePath outputFile, Action<TypeScriptClientGeneratorSettings> handler = null)
        {
            var settings = new TypeScriptClientGeneratorSettings();
            handler?.Invoke(settings);
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
        public NSwagRunner GenerateCSharpController(FilePath outputFile, Action<CSharpControllerGeneratorSettings> handler = null)
        {
            var settings = new CSharpControllerGeneratorSettings();
            handler?.Invoke(settings);
            var generator = new CSharpControllerGenerator(Document, settings);
            WriteToFile(outputFile, generator.GenerateFile());
            return this;
        }

        private void WriteToFile(FilePath file, string content)
        {
            using (var writer = new StreamWriter(Context.FileSystem.GetFile(file).OpenWrite()))
            {
                writer.Write(content);
            }
        }

    }
}
