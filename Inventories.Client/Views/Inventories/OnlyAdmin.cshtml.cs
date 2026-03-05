using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Inventories.Client.Views.Inventories
{
    public class OnlyAdmin : PageModel
    {
        private readonly ILogger<OnlyAdmin> _logger;

        public OnlyAdmin(ILogger<OnlyAdmin> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}