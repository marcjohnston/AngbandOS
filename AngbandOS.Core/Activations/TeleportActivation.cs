// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Long range teleport.
/// </summary>
[Serializable]
internal class TeleportActivation : Activation
{
    private TeleportActivation(Game game) : base(game) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "Your {0} twists space around you...";

    protected override bool OnActivate(Item item)
    {
        Game.RunScriptInt(nameof(TeleportSelfScript), 100);
        return true;
    }

    public override int RechargeTime() => 45;

    public override int Value => 2000;

    public override string Name => "Teleport (100)";

    public override string Frequency => "45";
}
