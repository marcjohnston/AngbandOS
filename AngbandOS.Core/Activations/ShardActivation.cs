// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a shard ball for 120 + level damage.
/// </summary>
[Serializable]
internal class ShardActivation : DirectionalActivation
{
    private ShardActivation(Game game) : base(game) { }
    public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ShardProjectile)), direction, 120 + Game.ExperienceLevel.IntValue, 2);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Shard ball (120+level)";

    public override string Frequency => "400";
}
