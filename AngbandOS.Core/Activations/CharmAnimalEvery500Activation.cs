// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm multiple animals.
/// </summary>
[Serializable]
internal class CharmAnimalEvery500Activation : Activation
{
    private CharmAnimalEvery500Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "";

    protected override string RechargeTimeRollExpression => "500";

    protected override bool OnActivate(Item item)
    {
        return Game.RunCancellableScript(nameof(CharmOthersScript));
    }

    public override int Value => 12500;

    public override string Name => "Charm animal";

    public override string Frequency => "500";
}
