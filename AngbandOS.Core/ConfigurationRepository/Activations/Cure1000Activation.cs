// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Heal 1000 health and remove all bleeding.
/// </summary>
[Serializable]
internal class Cure1000Activation : Activation
{
    private Cure1000Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 10;

    public override string? PreActivationMessage => "It glows a bright white...";

    public override bool Activate()
    {
        SaveGame.MsgPrint("You feel much better...");
        SaveGame.RestoreHealth(1000);
        SaveGame.TimedBleeding.ResetTimer();
        return true;
    }

    public override int RechargeTime() => 888;

    public override int Value => 15000;

    public override string Name => "heal 1000 hit points";

    public override string Description => $"{Name} every 888 turns";
}