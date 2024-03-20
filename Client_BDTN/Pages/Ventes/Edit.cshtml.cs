using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client_BDTN.API;

namespace Client_BDTN.Pages.Ventes
{
    public class EditModel : PageModel
    {
        private readonly IVenteClient _client;

        public EditModel(IVenteClient client)
        {
            _client = client;
        }

        [BindProperty]
        public Vente Vente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var vente =  await _client.VentesGETAsync(id.Value);
            if (vente == null)
            {
                return NotFound();
            }
            Vente = vente;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _client.VentesPUTAsync(Vente.Id, Vente);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

        
    }
}
