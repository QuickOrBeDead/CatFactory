﻿using System.Collections.Generic;
using System.Linq;

namespace CatFactory.ObjectOrientedProgramming
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeManager
    {
        static TypeManager()
        {
            ObjectDefinitions = new List<IObjectDefinition>();
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<IObjectDefinition> ObjectDefinitions { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectDefinition"></param>
        public static void Register(IObjectDefinition objectDefinition)
        {
            if (!ObjectDefinitions.Contains(objectDefinition))
                ObjectDefinitions.Add(objectDefinition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static IObjectDefinition GetItemByFullName(string fullName)
            => ObjectDefinitions.FirstOrDefault(item => item.FullName == fullName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<IObjectDefinition> GetItemsByName(string name)
            => ObjectDefinitions.Where(item => item.FullName == name);
    }
}
