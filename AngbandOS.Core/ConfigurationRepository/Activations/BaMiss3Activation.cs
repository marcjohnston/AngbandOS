// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a 'magic missile' cone that does 300 damage.
/// </summary>
[Serializable]
internal class BaMiss3Activation : DirectionalActivation
{
    private BaMiss3Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => ""; // No message is displayed to the player.

    protected override string? PostAimingMessage => "You breathe the elements.";

    public override int RechargeTime() => 500;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), direction, 300, -4);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "elemental breath (300)";

    public override string Description => $"{Name} every 500 turns";
}
