﻿using System;
using System.Collections.Generic;
using System.Linq;
using CatFactory.Diagnostics;
using Microsoft.Extensions.Logging;

namespace CatFactory.Mapping
{
    /// <summary>
    /// Represents a validator for database's structure
    /// </summary>
    public class DatabaseValidator : IDatabaseValidator
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CatFactory.Mapping.DatabaseValidator"/> class
        /// </summary>
        public DatabaseValidator()
        {
        }

        /// <summary>
        /// Gets a sequence that contains all validation messages from validate feature
        /// </summary>
        /// <param name="database">A database instance</param>
        /// <returns></returns>
        public virtual IEnumerable<ValidationMessage> Validate(Database database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            foreach (var table in database.Tables)
            {
                if (table.Columns.Count == 0)
                {
                    yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' doesn't have columns", table.FullName));
                    continue;
                }

                foreach (var column in table.Columns)
                {
                    if (string.IsNullOrEmpty(column.Name))
                        yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' has one column without name", table.FullName));
                    else if (column.Name.Trim().Length == 0)
                        yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' has one column without name", table.FullName));
                    else if (table.Columns.Where(item => item.Name == column.Name).Count() > 1)
                        yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' has more than one column with name: '{1}'", table.FullName, column.Name));
                }

                if (table.Identity != null)
                {
                    if (table.Columns.Where(item => item.Name == table.Identity.Name).Count() == 0)
                        yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' has a null reference on identity, column: '{1}'", table.FullName, table.Identity.Name));
                }

                if (table.PrimaryKey == null)
                {
                    yield return new ValidationMessage(LogLevel.Warning, string.Format("The table '{0}' doesn't have definition for primary key", table.FullName));
                }
                else
                {
                    var flag = false;

                    foreach (var column in table.Columns)
                    {
                        if (table.PrimaryKey.Key.Contains(column.Name))
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (!flag)
                        yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' has a null reference on primary key, key: '{1}'", table.FullName, string.Join(",", table.PrimaryKey.Key.Select(item => item))));
                }

                foreach (var unique in table.Uniques)
                {
                    var flag = false;

                    foreach (var column in table.Columns)
                    {
                        if (unique.Key.Contains(column.Name))
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (!flag)
                        yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' has a null reference on unique, key: '{1}'", table.FullName, string.Join(",", unique.Key.Select(item => item))));
                }

                foreach (var foreignKey in table.ForeignKeys)
                {
                    var flag = false;

                    foreach (var column in table.Columns)
                    {
                        if (foreignKey.Key.Contains(column.Name))
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (!flag)
                        yield return new ValidationMessage(LogLevel.Error, string.Format("The table '{0}' has a null reference on foreign, key: '{1}'", table.FullName, string.Join(",", foreignKey.Key.Select(item => item))));
                }
            }
        }
    }
}
