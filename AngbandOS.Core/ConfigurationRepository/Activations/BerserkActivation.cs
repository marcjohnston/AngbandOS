// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Bless us and make us a superhero.
/// </summary>
[Serializable]
internal class BerserkActivation : Activation
{
    private BerserkActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "";

    public override bool Activate()
    {
        SaveGame.TimedSuperheroism.AddTimer(SaveGame.DieRoll(50) + 50);
        SaveGame.TimedBlessing.AddTimer(SaveGame.DieRoll(50) + 50);
        return true;
    }

    public override int RechargeTime() => 100 + SaveGame.DieRoll(100);

    public override int Value => 800;

    public override string Description => "heroism and berserk (dur 50+d50) every 100+d100 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
}
