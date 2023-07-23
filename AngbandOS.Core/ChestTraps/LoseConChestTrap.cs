// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ChestTraps;

[Serializable]
internal class LoseConChestTrap : ChestTrap
{
    private LoseConChestTrap(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(ActivateChestTrapEventArgs eventArgs)
    {
        SaveGame.MsgPrint("A small needle has pricked you!");
        SaveGame.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
        SaveGame.TryDecreasingAbilityScore(Ability.Constitution);
    }
    public override string Description => "(Poison Needle)";
}
