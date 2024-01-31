// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TeleportLevelScript : Script, IScript
{
    private TeleportLevelScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.HasAntiTeleport)
        {
            SaveGame.MsgPrint("A mysterious force prevents you from teleporting!");
            return;
        }
        var downDesc = SaveGame.CurDungeon.Tower ? "You rise up through the ceiling." : "You sink through the floor.";
        var upDesc = SaveGame.CurDungeon.Tower ? "You sink through the floor." : "You rise up through the ceiling.";
        if (SaveGame.CurrentDepth <= 0)
        {
            SaveGame.MsgPrint(downDesc);
            SaveGame.DoCmdSaveGame(true);
            SaveGame.CurrentDepth++;
            SaveGame.NewLevelFlag = true;
        }
        else if (SaveGame.IsQuest(SaveGame.CurrentDepth) || SaveGame.CurrentDepth >= SaveGame.CurDungeon.MaxLevel)
        {
            SaveGame.MsgPrint(upDesc);
            SaveGame.DoCmdSaveGame(true);
            SaveGame.CurrentDepth--;
            SaveGame.NewLevelFlag = true;
        }
        else if (SaveGame.Rng.RandomLessThan(100) < 50)
        {
            SaveGame.MsgPrint(upDesc);
            SaveGame.DoCmdSaveGame(true);
            SaveGame.CurrentDepth--;
            SaveGame.NewLevelFlag = true;
            SaveGame.CameFrom = LevelStart.StartRandom;
        }
        else
        {
            SaveGame.MsgPrint(downDesc);
            SaveGame.DoCmdSaveGame(true);
            SaveGame.CurrentDepth++;
            SaveGame.NewLevelFlag = true;
        }
        SaveGame.DoCmdSaveGame(true);
        SaveGame.CurrentDepth++;
        SaveGame.NewLevelFlag = true;
        SaveGame.PlaySound(SoundEffectEnum.TeleportLevel);
    }
}
