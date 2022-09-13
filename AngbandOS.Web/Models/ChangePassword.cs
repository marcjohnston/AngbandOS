namespace AngbandOS.Web.Models;

public class ChangePassword
{
    public string CurrentPassword { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
}