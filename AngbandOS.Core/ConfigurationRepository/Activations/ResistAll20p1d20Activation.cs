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
internal class ResistAll20p1d20Activation : Activation
{
    private ResistAll20p1d20Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "Your {0} glows many colors...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.AcidResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.LightningResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.FireResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.ColdResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        SaveGame.PoisonResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        return true;
    }

    public override int RechargeTime() => 111;

    public override int Value => 5000;

    public override string Name => "Resist elements (40+d40)";

    public override string Frequency => "200";
}
