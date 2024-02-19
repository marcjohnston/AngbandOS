// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us temporary resistance to the basic elements.
/// </summary>
[Serializable]
internal class ResistAllActivation : Activation
{
    private ResistAllActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "It glows many colors...";

    public override bool Activate()
    {
        SaveGame.TimedAcidResistance.AddTimer(SaveGame.DieRoll(40) + 40);
        SaveGame.TimedLightningResistance.AddTimer(SaveGame.DieRoll(40) + 40);
        SaveGame.TimedFireResistance.AddTimer(SaveGame.DieRoll(40) + 40);
        SaveGame.TimedColdResistance.AddTimer(SaveGame.DieRoll(40) + 40);
        SaveGame.TimedPoisonResistance.AddTimer(SaveGame.DieRoll(40) + 40);
        return true;
    }

    public override int RechargeTime() => 200;

    public override int Value => 5000;

    public override string Name => "resist elements (dur 40+d40)";

    public override string Description => $"{Name} every 200 turns";
}
