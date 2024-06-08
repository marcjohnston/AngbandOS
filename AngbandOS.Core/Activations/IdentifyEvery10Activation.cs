// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Identify an item.
/// </summary>
[Serializable]
internal class IdentifyEvery10Activation : Activation
{
    private IdentifyEvery10Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows yellow...";

    protected override bool OnActivate(Item item)
    {
        return !Game.RunCancellableScript(nameof(IdentifyItemCancellableScript));
    }

    public override int RechargeTime() => 10;

    public override int Value => 1250;

    public override string Name => "Identify";

    public override string Frequency => "10";
}
