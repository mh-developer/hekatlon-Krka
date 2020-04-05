using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models.Account
{
    public class ConfirmEmailModel
    {
        [TempData] public string StatusMessage { get; set; }
    }
}