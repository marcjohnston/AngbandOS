// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SayLocationAndFeelingScript : Script
{
    private SayLocationAndFeelingScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        if (SaveGame.CurrentDepth <= 0)
        {
            // If we need to say where we are, do so
            if (SaveGame.Wilderness[SaveGame.WildernessY][SaveGame.WildernessX].Town != null)
            {
                SaveGame.MsgPrint($"You are in {SaveGame.CurTown.Name}.");
            }
            else if (SaveGame.Wilderness[SaveGame.WildernessY][SaveGame.WildernessX].Dungeon != null)
            {
                SaveGame.MsgPrint($"You are outside {SaveGame.Wilderness[SaveGame.WildernessY][SaveGame.WildernessX].Dungeon.Name}.");
            }
            else
            {
                SaveGame.MsgPrint("You are wandering around outside.");
            }
        }
        else
        {
            SaveGame.MsgPrint($"You are in {SaveGame.CurDungeon.Name}.");
            if (SaveGame.IsQuest(SaveGame.CurrentDepth))
            {
                SaveGame.PrintQuestMessage();
            }
        }
        SaveGame.RunScript(nameof(SayFeelingScript));
        return false;
    }
}
