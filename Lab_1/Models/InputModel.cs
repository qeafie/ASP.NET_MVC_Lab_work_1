using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class InputModel
    {
        public string Text { get; set; }
        public IEnumerable<string> ListBoxValues { get; set; }
        public IEnumerable<string> DropdownListValues { get; set; }
        
        public string Radio { get; set; }
    }
}