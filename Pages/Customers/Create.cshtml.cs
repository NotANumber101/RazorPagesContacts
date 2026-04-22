using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesContacts.Models;
using RazorPagesContacts.Data;

public class CreateModel : PageModel
{
    private readonly CustomerDbContext _context;

    public CreateModel(CustomerDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        
        return Page();
    }

    [BindProperty]
    public Customer? Customer { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Customer != null) _context.Customer.Add(Customer);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}