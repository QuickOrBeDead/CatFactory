﻿using System.Collections.Generic;
using CatFactory.CodeFactory;
using CatFactory.Diagnostics;

namespace CatFactory.Tests.Models
{
    public class ProjectSettings : IProjectSettings
    {
        public virtual IEnumerable<ValidationMessage> Validate()
        {
            return null;
        }
    }
}
