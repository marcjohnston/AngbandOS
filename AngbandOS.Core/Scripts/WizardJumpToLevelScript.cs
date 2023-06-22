// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class WizardJumpToLevelScript : Script
    {
        private WizardJumpToLevelScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            if (SaveGame.CommandArgument <= 0)
            {
                string ppp = $"Jump to level (0-{SaveGame.CurDungeon.MaxLevel}): ";
                string def = $"{SaveGame.CurrentDepth}";
                if (!SaveGame.GetString(ppp, out string tmpVal, def, 10))
                {
                    return false;
                }
                SaveGame.CommandArgument = int.TryParse(tmpVal, out int i) ? i : 0;
            }
            if (SaveGame.CommandArgument < 1)
            {
                SaveGame.CommandArgument = 1;
            }
            if (SaveGame.CommandArgument > SaveGame.CurDungeon.MaxLevel)
            {
                SaveGame.CommandArgument = SaveGame.CurDungeon.MaxLevel;
            }
            SaveGame.MsgPrint($"You jump to dungeon level {SaveGame.CommandArgument}.");
            SaveGame.DoCmdSaveGame(true);
            SaveGame.CurrentDepth = SaveGame.CommandArgument;
            SaveGame.NewLevelFlag = true;
            return false;
        }
    }
}
