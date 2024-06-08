// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give temporary telepathy.
/// </summary>
[Serializable]
internal class TemporaryEsp20p1d30Every200Activation : Activation
{
    private TemporaryEsp20p1d30Every200Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "";

    protected override bool OnActivate(Item item)
    {
        Game.RunScript(nameof(AddTelepathy25p1d30Script));
        return true;
    }

    protected override string RechargeTimeRollExpression => "200";

    public override int Value => 1500;

    public override string Name => "Temporary ESP (25+d30)";

}
