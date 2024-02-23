// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Destroy nearby doors.
/// </summary>
[Serializable]
internal class DestDoorActivation : Activation
{
    private DestDoorActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It glows bright red...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.RunScript(nameof(DestroyAdjacentDoorsScript));
        return true;
    }

    public override int RechargeTime() => 10;

    public override int Value => 100;

    public override string Name => "Destroy doors";

    public override string Description => $"{Name.ToLower()} every 10 turns";
}
