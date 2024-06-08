// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class Teleport100Every1d50p50Activation : Activation
{
    private Teleport100Every1d50p50Activation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} twists space around you...";

    protected override bool OnActivate(Item item)
    {
        Game.RunScriptInt(nameof(TeleportSelfScript), 100);
        return true;
    }

    protected override string RechargeTimeRollExpression => "1d50+50";

    public override int Value => 2000;

    public override string Name => "Teleport (100)";

}
