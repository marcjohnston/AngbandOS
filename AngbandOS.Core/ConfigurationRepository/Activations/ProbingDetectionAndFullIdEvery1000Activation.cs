// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Detect everything and do probing and identify an item fully.
/// </summary>
[Serializable]
internal class ProbingDetectionAndFullIdEvery1000Activation : Activation
{
    private ProbingDetectionAndFullIdEvery1000Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 10;

    public override string? PreActivationMessage => "Your {0} glows brightly...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.RunScript(nameof(DetectionScript));
        SaveGame.Probing();
        SaveGame.RunScript(nameof(IdentifyItemFullyScript));
        return true;
    }

    public override int RechargeTime() => 1000;

    public override int Value => 12500;

    public override string Name => "Probing, detection and full id";

    public override string Frequency => "1000";
}
