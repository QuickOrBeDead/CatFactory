﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CatFactory.Collections;
using CatFactory.OOP;
using Microsoft.Extensions.Logging;

namespace CatFactory.CodeFactory
{
    public class CodeBuilder : ICodeBuilder
    {
        protected ILogger Logger;

        public CodeBuilder()
        {
        }

        public CodeBuilder(ILogger<ICodeBuilder> logger)
        {
            Logger = logger;
        }

        public string Tab { get; set; } = "\t";

        public string Indent(int count)
            => string.Concat(Enumerable.Repeat(Tab, count));

        public virtual string FileName
            => string.Empty;

        public virtual string FileExtension
            => string.Empty;

        public virtual string FilePath
            => string.Format("{0}.{1}", FileName, FileExtension);

        public IObjectDefinition ObjectDefinition { get; set; }

        [Obsolete("This property will replace with translating method")]
        public virtual string Code
            => string.Empty;

        public virtual void Translating()
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private List<ILine> m_lines;

        public List<ILine> Lines
        {
            get
            {
                return m_lines ?? (m_lines = new List<ILine>());
            }
            set
            {
                m_lines = value;
            }
        }

        public event TranslatedDefinition TranslatedDefinition;

        protected void OnTranslatedDefinition(TranslatedDefinitionEventArgs args)
        {
            TranslatedDefinition?.Invoke(this, args);
        }

        public string OutputDirectory { get; set; }

        public bool ForceOverwrite { get; set; }

        public virtual void CreateOutputDirectory()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateOutputDirectory));

            if (!Directory.Exists(OutputDirectory))
            {
                Logger?.LogInformation("Creating '{0}' directory...", OutputDirectory);

                Directory.CreateDirectory(OutputDirectory);
            }
        }

        public virtual void CreateFile(string subdirectory = "", string fileName = "")
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(CreateFile));

            CreateOutputDirectory();

            var filePath = string.IsNullOrEmpty(fileName) ? Path.Combine(OutputDirectory, subdirectory, FilePath) : Path.Combine(OutputDirectory, subdirectory, fileName);

            if (!ForceOverwrite && File.Exists(filePath))
                throw new CodeFactoryException(string.Format("The '{0}' file alread exists, if you want to overwrite set ForceOverwrite property as true", filePath));

            if (!string.IsNullOrEmpty(subdirectory))
            {
                var subdirectoryPath = Path.Combine(OutputDirectory, subdirectory);

                if (!Directory.Exists(subdirectoryPath))
                {
                    Logger?.LogInformation("Creating '{0}' directory...", subdirectoryPath);

                    Directory.CreateDirectory(subdirectoryPath);
                }
            }

            Logger?.LogInformation("Creating '{0}' file...", filePath);

            Translating();

            OnTranslatedDefinition(new TranslatedDefinitionEventArgs(Logger));

            TextFileHelper.CreateFile(filePath, Lines.ToStringBuilder().ToString());
        }
    }
}
