// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class WordOfRecallEvery200Activation : DirectionalActivation
{
    private WordOfRecallEvery200Activation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} glows soft white...";
    public override int RechargeTime() => 200;

    protected override bool Activate(int direction)
    {
        Game.RunScript(nameof(ToggleRecallScript));
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Word of recall";

    public override string Frequency => "200";
}

