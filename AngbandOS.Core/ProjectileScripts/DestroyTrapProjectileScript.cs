// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ProjectileScripts;

[Serializable]
internal class DestroyTrapProjectileScript : ProjectileScript
{
    private DestroyTrapProjectileScript(Game game) : base(game) { }

    public override bool Stop => false;
    public override bool Kill => false;
    public override bool Jump => false;
    public override bool Beam => true;
    public override bool Grid => true;
    public override bool Item => true;
    public override bool Thru => true;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(DestroyTrapProjectile);
    protected override string DamageRollExpression => "0";
    public override bool? Identified => null;
}
