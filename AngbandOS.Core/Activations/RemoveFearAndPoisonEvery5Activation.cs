// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Remove fear and poison.
/// </summary>
[Serializable]
internal class RemoveFearAndPoisonEvery5Activation : Activation
{
    private RemoveFearAndPoisonEvery5Activation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    protected override bool OnActivate(Item item)
    {
        Game.FearTimer.ResetTimer();
        Game.PoisonTimer.ResetTimer();
        return true;
    }

    public override int RechargeTime() => 5;

    public override int Value => 1000;

    public override string Name => "Remove fear and cure poison";

    public override string Frequency => "5";
}
