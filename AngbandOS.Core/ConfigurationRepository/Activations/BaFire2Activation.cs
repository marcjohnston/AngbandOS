// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a fire ball that does 120 damage with a larger radius.
/// </summary>
[Serializable]
internal class BaFire2Activation : DirectionalActivation
{
    private BaFire2Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 66;

    public override string? PreActivationMessage => "It glows deep red...";

    public override int RechargeTime() => SaveGame.RandomLessThan(225) + 225;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), direction, 120, 3);
        return true;
    }

    public override int Value => 1750;

    public override string Name => "Fire ball (120)";

    public override string Description => $"{Name.ToLower()} every 225+d225 turns";
}
