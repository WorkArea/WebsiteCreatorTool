﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCreatorTool.Data
{
    /// <summary>
    /// Encapsulates a unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves changes to all objects that have changed within the unit of work.
        /// </summary>
        void SaveChanges();
    }
}
