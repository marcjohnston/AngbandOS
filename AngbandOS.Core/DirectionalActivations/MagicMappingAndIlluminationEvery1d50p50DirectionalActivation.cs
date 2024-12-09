// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class MagicMappingAndIlluminationEvery1d50p50DirectionalActivation : DirectionalActivation
{
    private MagicMappingAndIlluminationEvery1d50p50DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "The {0} shines brightly...";
    protected override string RechargeTimeRollExpression => "1d50+50";
    protected override bool Activate(int direction)
    {
        Game.RunScript(nameof(MapAreaScript));
        Game.LightArea(Game.DiceRoll(2, 15), 3);
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Magic mapping and light";

}

