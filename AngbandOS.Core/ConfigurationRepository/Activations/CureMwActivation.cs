// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Heal 4d8 health and reduce bleeding.
/// </summary>
[Serializable]
internal class CureMwActivation : Activation
{
    private CureMwActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It radiates deep purple...";

    protected override bool OnActivate(Item item)
    {
        SaveGame.RestoreHealth(SaveGame.DiceRoll(4, 8));
        SaveGame.TimedBleeding.SetTimer((SaveGame.TimedBleeding.TurnsRemaining / 2) - 50);
        return true;
    }

    public override int RechargeTime() => SaveGame.RandomLessThan(3) + 3;

    public override int Value => 750;

    public override string Name => "Heal 4d8 & wounds";

    public override string Description => $"{Name.ToLower()} every 3+d3 turns";
}
