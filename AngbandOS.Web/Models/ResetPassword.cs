namespace AngbandOS.Web;

public class ResetPassword
{
    public string ResetPasswordToken { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
}