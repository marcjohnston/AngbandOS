// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MageLevel30HolyOrbScript : ProjectileScriptGameConfiguration
{
    public override string ProjectileBindingKey => nameof(HolyFireProjectile);
    public override string DamageRollExpression => "3d6+X+(X/2)";
    public override string RadiusRollExpression => "3";
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Thru => true;
    public override bool Hide => false;
    public override bool Stop => true;
}
