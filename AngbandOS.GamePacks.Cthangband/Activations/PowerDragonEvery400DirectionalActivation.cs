// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerDragonEvery400DirectionalActivation : ActivationGameConfiguration
{
    
    public override string? PreActivationMessage => "You breathe the elements...";

    public override string RechargeTimeRollExpression => "400";

    public override string ActivationCancellableScriptItemBindingKey => nameof(SystemScriptsEnum.PowerDragonScript);

    public override int Value => 100000;

    public override string Name => "Breathe elements (300), berserk rage, bless, and resistance";

}
