// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Recharge an item.
/// </summary>
[Serializable]
internal class RechargeActivation : Activation
{
    private RechargeActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "";

    public override bool Activate()
    {
        SaveGame.Recharge(60);
        return true;
    }

    public override int RechargeTime() => 70;

    public override int Value => 1000;

    public override string Description => "recharging every 70 turns";
}
