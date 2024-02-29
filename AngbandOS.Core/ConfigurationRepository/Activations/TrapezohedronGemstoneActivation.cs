// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Word of Recall.
/// </summary>
[Serializable]
internal class TrapezohedronGemstoneActivation : Activation
{
    private TrapezohedronGemstoneActivation(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns a random chance of 0, because this activation only applies to a fixed artifact.
    /// </summary>
    public override int RandomChance => 0;

    public override string? PreActivationMessage => "";

    protected override bool OnActivate(Item item)
    {
        SaveGame.MsgPrint("The gemstone flashes bright red!");
        SaveGame.RunScript(nameof(LightScript));
        SaveGame.MsgPrint("The gemstone drains your vitality...");
        SaveGame.TakeHit(base.SaveGame.DiceRoll(3, 8), "the Gemstone 'Trapezohedron'");
        SaveGame.DetectTraps();
        SaveGame.DetectDoors();
        SaveGame.DetectStairs();
        if (SaveGame.GetCheck("Activate recall? "))
        {
            SaveGame.RunScript(nameof(ToggleRecallScript));
        }
        return true;
    }

    public override int RechargeTime() => SaveGame.RandomLessThan(20) + 20;

    public override int Value => 300;

    public override string Name => "Clairvoyance and recall, draining you";

    public override string Frequency => "20+d20";
}
