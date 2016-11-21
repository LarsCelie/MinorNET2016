using FrontEnd.Agents.Models;
using FrontEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Viewmodels
{
    public class ImportViewModel
    {
        public PostSuccess success { get; set; }
        public PostFailure failure { get; set; }
        public IllegalFormatException validationError { get; set; }

        public int duplicates
        {
            get
            {
                return success.Total.Value - success.Inserted.Value;
            }
        }
    }
}
