// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Mass carnage creatures near the player.
/// </summary>
[Serializable]
internal class MassGenoActivation : Activation
{
    private MassGenoActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "It lets out a long, shrill note...";

    public override bool Activate()
    {
        SaveGame.RunScriptBool(nameof(MassCarnageScript), true);
        return true;
    }

    public override int RechargeTime() => 1000;

    public override int Value => 10000;

    public override string Description => "mass carnage every 1000 turns";
}
