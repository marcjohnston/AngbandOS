// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Turn an item to gold.
/// </summary>
[Serializable]
internal class AlchemyEvery500Activation : Activation
{
    private AlchemyEvery500Activation(Game game) : base(game) { }

    
    public override string? PreActivationMessage => "Your {0} glows bright yellow...";

    protected override bool OnActivate(Item item)
    {
        return Game.RunCancellableScript(nameof(AlchemyScript));
    }

    protected override string RechargeTimeRollExpression => "500";

    public override int Value => 10000;

    public override string Name => "Alchemy";
    public override string Frequency => "500";
}
