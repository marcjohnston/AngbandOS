// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a magic missile that does 2d6 damage
/// </summary>
[Serializable]
internal class BoMiss1Activation : DirectionalActivation
{
    private BoMiss1Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It glows extremely brightly...";

    public override int RechargeTime() => 2;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), direction, SaveGame.DiceRoll(2, 6));
        return true;
    }

    public override int Value => 250;

    public override string Name => "magic missile (2d6)";

    public override string Description => $"{Name} every 2 turns";
}
