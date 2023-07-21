// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot an arrow that does 150 damage.
/// </summary>
[Serializable]
internal class BoMiss2Activation : DirectionalActivation
{
    private BoMiss2Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 66;

    public override string? PreActivationMessage => "It grows magical spikes...";

    public override int RechargeTime() => Program.Rng.RandomLessThan(90) + 90;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<ArrowProjectile>(), direction, 150);
        return true;
    }

    public override int Value => 1000;

    public override string Description => "arrows (150) every 90+d90 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
}
