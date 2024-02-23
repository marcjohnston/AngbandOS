// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Place a Yellow Sign.
/// </summary>
[Serializable]
internal class RuneExploActivation : Activation
{
    private RuneExploActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "It glows a sickly yellow...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.RunScript(nameof(YellowSignScript));
        return true;
    }

    public override int RechargeTime() => 200;

    public override int Value => 4000;

    public override string Name => "Yellow Sign";

    public override string Description => $"{Name.ToLower()} every 200 turns";
}
