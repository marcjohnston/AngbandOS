// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a 12-damage ball of poison
/// </summary>
[Serializable]
internal class BaPois1Activation : DirectionalActivation
{
    private BaPois1Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It throbs deep green...";

    public override int RechargeTime() => SaveGame.RandomLessThan(4) + 4;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), direction, 12, 3);
        return true;
    }

    public override int Value => 300;

    public override string Name => "Stinking cloud (12), rad. 3";

    public override string Description => $"{Name.ToLower()}, every 4+d4 turns";
}
