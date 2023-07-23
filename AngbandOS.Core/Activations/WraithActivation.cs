// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary etherealness.
/// </summary>
[Serializable]
internal class WraithActivation : Activation
{
    private WraithActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 5;

    public override string? PreActivationMessage => "";

    public override bool Activate()
    {
        SaveGame.TimedEtherealness.AddTimer(SaveGame.Rng.DieRoll(SaveGame.ExperienceLevel / 2) + (SaveGame.ExperienceLevel / 2));
        return true;
    }

    public override int RechargeTime() => 1000;

    public override int Value => 25000;

    public override string Description => "wraith form (level/2 + d(level/2)) every 1000 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
}
