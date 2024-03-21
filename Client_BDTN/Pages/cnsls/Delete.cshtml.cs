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
    public class DeleteModel : PageModel
    {
        private readonly IVenteClient _client;

        public DeleteModel(IVenteClient client)
        {
            _client = client;
        }

        [BindProperty]
      public Cnsl cnsl { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await _client.CnslsDELETEAsync(id.Value);
            }
            catch(Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
