// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class IlluminationEvery1d10p10Activation : DirectionalActivation
{
    private IlluminationEvery1d10p10Activation(Game game) : base(game) { }

    public override string? PreActivationMessage => "The {0} wells with clear light...";
    public override int RechargeTime() => Game.DieRoll(10) + 10;
    protected override bool Activate(int direction)
    {
        Game.LightArea(base.Game.DiceRoll(2, 15), 3);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Illumination";

    public override string Frequency => "10+d10";
}

