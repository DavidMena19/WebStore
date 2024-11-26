using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Models
{
    internal class ErrorViewModel
    {
        public string? RequestedId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestedId);
    }
}
