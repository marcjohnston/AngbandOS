using Cthangband.StaticData;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Repeat the level feeling for the player and also say where we are
    /// </summary>
    [Serializable]
    internal class FeelingAndLocationCommand : ICommand
    {
        public char Key => 'H';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DoCmdFeeling(saveGame.Player, saveGame.Level, false);
        }

        public static void DoCmdFeeling(Player player, Level level, bool feelingOnly)
        {
            // Some sanity checks
            if (level.DangerFeeling < 0)
            {
                level.DangerFeeling = 0;
            }
            if (level.DangerFeeling > 10)
            {
                level.DangerFeeling = 10;
            }
            if (level.TreasureFeeling < 0)
            {
                level.TreasureFeeling = 0;
            }
            if (level.TreasureFeeling > 10)
            {
                level.TreasureFeeling = 10;
            }
            if (SaveGame.Instance.CurrentDepth <= 0)
            {
                // If we need to say where we are, do so
                if (!feelingOnly)
                {
                    if (SaveGame.Instance.Wilderness[player.WildernessY][player.WildernessX].Town != null)
                    {
                        SaveGame.Instance.MsgPrint($"You are in {SaveGame.Instance.CurTown.Name}.");
                    }
                    else if (SaveGame.Instance.Wilderness[player.WildernessY][player.WildernessX].Dungeon != null)
                    {
                        SaveGame.Instance.MsgPrint(
                            $"You are outside {SaveGame.Instance.Wilderness[player.WildernessY][player.WildernessX].Dungeon.Name}.");
                    }
                    else
                    {
                        SaveGame.Instance.MsgPrint("You are wandering around outside.");
                    }
                }
                // If we're not in a dungeon, there's no feeling to be had
                return;
            }
            // If we need to say where we are, do so
            if (!feelingOnly)
            {
                SaveGame.Instance.MsgPrint($"You are in {SaveGame.Instance.CurDungeon.Name}.");
                if (SaveGame.Instance.Quests.IsQuest(SaveGame.Instance.CurrentDepth))
                {
                    SaveGame.Instance.Quests.PrintQuestMessage();
                }
            }
            // Special feeling overrides the normal two-part feeling
            if (level.DangerFeeling == 1 || level.TreasureFeeling == 1)
            {
                string message = GlobalData.DangerFeelingText[1];
                SaveGame.Instance.MsgPrint(player.GameTime.LevelFeel
                    ? message : GlobalData.DangerFeelingText[0]);
            }
            else
            {
                // Make the two-part feeling make a bit more sense by using the correct conjunction
                string conjunction = ", and ";
                if ((level.DangerFeeling > 5 && level.TreasureFeeling < 6) || (level.DangerFeeling < 6 && level.TreasureFeeling > 5))
                {
                    conjunction = ", but ";
                }
                string message = GlobalData.DangerFeelingText[level.DangerFeeling] + conjunction + GlobalData.TreasureFeelingText[level.TreasureFeeling];
                SaveGame.Instance.MsgPrint(player.GameTime.LevelFeel
                    ? message : GlobalData.DangerFeelingText[0]);
            }
        }
    }
}
