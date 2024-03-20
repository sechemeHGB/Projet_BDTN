using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_BDTN.API;

namespace Client_BDTN.Pages.Ventes
{
    public class DetailsModel : PageModel
    {
        private readonly IVenteClient _client;

        public DetailsModel(IVenteClient client)
        {
            _client = client;
        }
      public Vente Vente { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            Vente = await _client.VentesGETAsync(id.Value);

            if (Vente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
