﻿using System;
using System.Diagnostics;

namespace CatFactory.Mapping
{
    [DebuggerDisplay("Name={Name}, Type={Type}")]
    public class Column
    {
        public Column()
        {
        }

        public String Name { get; set; }

        public String Type { get; set; }

        public Int32 Length { get; set; }

        public Int16 Prec { get; set; }

        public Int16 Scale { get; set; }

        public Boolean Nullable { get; set; }

        public String Collation { get; set; }
    }
}
