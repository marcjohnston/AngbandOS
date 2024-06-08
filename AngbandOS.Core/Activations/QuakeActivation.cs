// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Cause an earthquake around the player.
/// </summary>
[Serializable]
internal class QuakeActivation : Activation
{
    private QuakeActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "";

    protected override string RechargeTimeRollExpression => "50";

    protected override bool OnActivate(Item item)
    {
        Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 10);
        return true;
    }

    public override int Value => 600;

    public override string Name => "Earthquake (rad 10)";

}
