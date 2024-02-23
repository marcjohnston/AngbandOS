// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Heal 700 health and remove all bleeding.
/// </summary>
[Serializable]
internal class Cure700Activation : Activation
{
    private Cure700Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "Your {0} glows deep blue...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.MsgPrint("You feel a warm tingling inside...");
        SaveGame.RestoreHealth(700);
        SaveGame.TimedBleeding.ResetTimer();
        return true;
    }

    public override int RechargeTime() => 250;

    public override int Value => 10000;

    public override string Name => "Heal 700 hit points";

    public override string Description => $"{Name.ToLower()} every 250 turns";
}
