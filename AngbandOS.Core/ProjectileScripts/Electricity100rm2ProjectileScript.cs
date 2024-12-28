// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Electricity100rm2ProjectileScript : ProjectileScript
{
    private Electricity100rm2ProjectileScript(Game game) : base(game) { }

    protected override string ProjectileBindingKey => nameof(ElecProjectile);
    protected override string DamageRollExpression => "100";
    protected override string RadiusRollExpression => "-2";
}
