// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a frost bolt that does 6d8 damage.
/// </summary>
[Serializable]
internal class BoCold1Activation : DirectionalActivation
{
    private BoCold1Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It is covered in frost...";

    public override int RechargeTime() => SaveGame.Rng.RandomLessThan(7) + 7;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), direction, SaveGame.Rng.DiceRoll(6, 8));
        return true;
    }

    public override int Value => 250;

    public override string Description => "frost bolt (6d8) every 7+d7 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
}
