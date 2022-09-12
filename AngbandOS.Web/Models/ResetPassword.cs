namespace AngbandOS.Web.Models;

public class ResetPassword
{
    public string ResetPasswordToken { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
}