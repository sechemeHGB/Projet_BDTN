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
    public class IndexModel : PageModel
    {
        private readonly IVenteClient _client;

        public IndexModel(IVenteClient client)
        {
            _client = client;
        }

        public IList<Cnsl> cnsl { get;set; } = default!;

        public async Task OnGetAsync()
        {
                cnsl = (await _client.CnslsAllAsync()).ToList();
            
        }
    }
}
