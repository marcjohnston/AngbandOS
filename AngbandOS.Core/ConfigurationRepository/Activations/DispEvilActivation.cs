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

    public override string? PreActivationMessage => "Your {0} floods the area with goodness...";

    public override int RechargeTime() => SaveGame.RandomLessThan(300) + 300;

    protected override bool OnActivate(Item item)
    {
        SaveGame.RunScriptInt(nameof(DispelEvil4xScript), SaveGame.ExperienceLevel * 5);
        return true;
    }

    public override int Value => 4000;

    public override string Name => "Dispel evil (level*5)";

    public override string Description => $"{Name.ToLower()} every 300+d300 turns";
}
