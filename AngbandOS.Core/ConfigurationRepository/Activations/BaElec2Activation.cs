// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a lightning storm that does 100 damage with a larger radius.
/// </summary>
[Serializable]
internal class BaElec2Activation : DirectionalActivation
{
    private BaElec2Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 0; // TODO: Confirm this artifact does not have a corresponding random chance.  It is only used with biased artifacts.

    public override string? PreActivationMessage => "It crackles with electricity...";

    public override int RechargeTime() => 500;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), direction, 100, 3);
        return true;
    }

    public override int Value => 1500;

    public override string Description => "ball of lightning (100) every 500 turns";
}
