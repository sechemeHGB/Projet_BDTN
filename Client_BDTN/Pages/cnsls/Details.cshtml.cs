using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_BDTN.API;

namespace Client_BDTN.Pages.cnsls
{
    public class DetailsModel : PageModel
    {
        private readonly IVenteClient _client;

        public DetailsModel(IVenteClient client)
        {
            _client = client;
        }

      public Cnsl cnsl { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cnsl = await _client.CnslsGETAsync(id.Value);
            if (cnsl == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
