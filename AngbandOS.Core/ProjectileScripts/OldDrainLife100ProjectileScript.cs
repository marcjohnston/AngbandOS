// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class OldDrainLife100ProjectileScript : ProjectileScript
{
    private OldDrainLife100ProjectileScript(Game game) : base(game) { }

    public override bool Stop => true;
    public override bool Kill => true;
    public override bool Jump => false;
    public override bool Beam => false;
    public override bool Grid => false;
    public override bool Item => false;
    public override bool Thru => false;
    public override bool Hide => false;
    protected override string ProjectileBindingKey => nameof(OldDrainLifeProjectile);
    protected override string DamageRollExpression => "100";
    public override bool? Identified => null; // The drain life actual had to affect a monster to know what it did. 
}
