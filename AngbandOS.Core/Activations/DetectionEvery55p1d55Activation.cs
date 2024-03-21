// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Detect everything.
/// </summary>
[Serializable]
internal class DetectionEvery55p1d55Activation : Activation
{
    private DetectionEvery55p1d55Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "Your {0} glows bright white...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.MsgPrint("An image forms in your mind...");
        SaveGame.RunScript(nameof(DetectionScript));
        return true;
    }

    public override int RechargeTime() => SaveGame.RandomLessThan(55) + 55;

    public override int Value => 1000;

    public override string Name => "Detection";

    public override string Frequency => "55+d55";
}
