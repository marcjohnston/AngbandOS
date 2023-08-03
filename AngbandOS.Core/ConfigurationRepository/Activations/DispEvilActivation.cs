// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Dispel evil with a strength of x5.
/// </summary>
[Serializable]
internal class DispEvilActivation : Activation
{
    private DispEvilActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "It floods the area with goodness...";

    public override int RechargeTime() => SaveGame.Rng.RandomLessThan(300) + 300;

    public override bool Activate()
    {
        SaveGame.DispelEvil(SaveGame.ExperienceLevel * 5);
        return true;
    }

    public override int Value => 4000;

    public override string Description => "dispel evil (level*5) every 300+d300 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
}
