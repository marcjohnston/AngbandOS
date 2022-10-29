using AngbandOS.Core;
using System;

namespace AngbandOS.Commands
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
            DoCmdFeeling(saveGame, false);
        }

        public static void DoCmdFeeling(SaveGame saveGame, bool feelingOnly)
        {
            // Some sanity checks
            if (saveGame.Level.DangerFeeling < 0)
            {
                saveGame.Level.DangerFeeling = 0;
            }
            if (saveGame.Level.DangerFeeling > 10)
            {
                saveGame.Level.DangerFeeling = 10;
            }
            if (saveGame.Level.TreasureFeeling < 0)
            {
                saveGame.Level.TreasureFeeling = 0;
            }
            if (saveGame.Level.TreasureFeeling > 10)
            {
                saveGame.Level.TreasureFeeling = 10;
            }
            if (saveGame.CurrentDepth <= 0)
            {
                // If we need to say where we are, do so
                if (!feelingOnly)
                {
                    if (saveGame.Wilderness[saveGame.Player.WildernessY][saveGame.Player.WildernessX].Town != null)
                    {
                        saveGame.MsgPrint($"You are in {saveGame.CurTown.Name}.");
                    }
                    else if (saveGame.Wilderness[saveGame.Player.WildernessY][saveGame.Player.WildernessX].Dungeon != null)
                    {
                        saveGame.MsgPrint(
                            $"You are outside {saveGame.Wilderness[saveGame.Player.WildernessY][saveGame.Player.WildernessX].Dungeon.Name}.");
                    }
                    else
                    {
                        saveGame.MsgPrint("You are wandering around outside.");
                    }
                }
                // If we're not in a dungeon, there's no feeling to be had
                return;
            }
            // If we need to say where we are, do so
            if (!feelingOnly)
            {
                saveGame.MsgPrint($"You are in {saveGame.CurDungeon.Name}.");
                if (saveGame.Quests.IsQuest(saveGame.CurrentDepth))
                {
                    saveGame.Quests.PrintQuestMessage();
                }
            }
            // Special feeling overrides the normal two-part feeling
            if (saveGame.Level.DangerFeeling == 1 || saveGame.Level.TreasureFeeling == 1)
            {
                string message = GlobalData.DangerFeelingText[1];
                saveGame.MsgPrint(saveGame.Player.GameTime.LevelFeel
                    ? message : GlobalData.DangerFeelingText[0]);
            }
            else
            {
                // Make the two-part feeling make a bit more sense by using the correct conjunction
                string conjunction = ", and ";
                if ((saveGame.Level.DangerFeeling > 5 && saveGame.Level.TreasureFeeling < 6) || (saveGame.Level.DangerFeeling < 6 && saveGame.Level.TreasureFeeling > 5))
                {
                    conjunction = ", but ";
                }
                string message = GlobalData.DangerFeelingText[saveGame.Level.DangerFeeling] + conjunction + GlobalData.TreasureFeelingText[saveGame.Level.TreasureFeeling];
                saveGame.MsgPrint(saveGame.Player.GameTime.LevelFeel
                    ? message : GlobalData.DangerFeelingText[0]);
            }
        }
    }
}
