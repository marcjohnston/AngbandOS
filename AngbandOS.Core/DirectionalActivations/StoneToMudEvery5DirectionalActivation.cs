// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class StoneToMudEvery5DirectionalActivation : DirectionalActivation
{
    private StoneToMudEvery5DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} pulsates...";
    protected override string RechargeTimeRollExpression => "5";
    protected override bool Activate(int direction)
    {
        Game.WallToMud(direction);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Stone to mud";

}

