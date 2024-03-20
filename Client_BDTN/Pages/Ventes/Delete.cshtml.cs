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
    public class DeleteModel : PageModel
    {
        private readonly IVenteClient _client;

        public DeleteModel(IVenteClient client)
        {
            _client = client;
        }

        [BindProperty]
      public Vente Vente { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) 
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await _client.VentesDELETEAsync(id.Value);
            }
            catch(Exception ex)
            {
                return RedirectToPage("./Index");
            }
           

            return RedirectToPage("./Index");
        }
    }
}
