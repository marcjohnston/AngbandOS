// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Shoot a frost ball that does 48 damage.
/// </summary>
[Serializable]
public class BallOfCold48r2Every5p1d5DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "Your {0} is covered in frost...";

    public override string RechargeTimeRollExpression => "1d5+5";

    public override string ActivationCancellableScriptItemBindingKey => nameof(Cold48r2ProjectileScript);

    public override int Value => 750;
    public override string Name => "Ball of cold (48)";

}
