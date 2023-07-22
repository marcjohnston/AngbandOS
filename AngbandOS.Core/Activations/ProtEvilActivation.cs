// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us protection from evil.
/// </summary>
[Serializable]
internal class ProtEvilActivation : Activation
{
    private ProtEvilActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 75;

    public override string? PreActivationMessage => "It lets out a shrill wail...";

    public override bool Activate()
    {
        int k = 3 * SaveGame.ExperienceLevel;
        SaveGame.TimedProtectionFromEvil.AddTimer(Program.Rng.DieRoll(25) + k);
        return true;
    }

    public override int RechargeTime() => Program.Rng.RandomLessThan(225) + 225;

    public override int Value => 5000;

    public override string Description => "protect evil (dur level*3 + d25) every 225+d225 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
}
