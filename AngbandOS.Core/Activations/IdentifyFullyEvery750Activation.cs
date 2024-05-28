// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Identify an item fully.
/// </summary>
[Serializable]
internal class IdentifyFullyEvery750Activation : Activation
{
    private IdentifyFullyEvery750Activation(Game game) : base(game) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "Your {0} glows yellow...";

    protected override bool OnActivate(Item item)
    {
        return Game.RunCancellableScript(nameof(IdentifyItemFullyCancellableScript));
    }

    public override int RechargeTime() => 750;

    public override int Value => 10000;

    public override string Name => "Identify true";

    public override string Frequency => "750";
}
