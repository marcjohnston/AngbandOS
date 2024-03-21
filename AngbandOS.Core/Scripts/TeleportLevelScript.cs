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
    private TeleportLevelScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.HasAntiTeleport)
        {
            Game.MsgPrint("A mysterious force prevents you from teleporting!");
            return;
        }
        var downDesc = Game.CurDungeon.Tower ? "You rise up through the ceiling." : "You sink through the floor.";
        var upDesc = Game.CurDungeon.Tower ? "You sink through the floor." : "You rise up through the ceiling.";
        if (Game.CurrentDepth <= 0)
        {
            Game.MsgPrint(downDesc);
            Game.DoCmdSaveGame(true);
            Game.CurrentDepth++;
            Game.NewLevelFlag = true;
        }
        else if (Game.IsQuest(Game.CurrentDepth) || Game.CurrentDepth >= Game.CurDungeon.MaxLevel)
        {
            Game.MsgPrint(upDesc);
            Game.DoCmdSaveGame(true);
            Game.CurrentDepth--;
            Game.NewLevelFlag = true;
        }
        else if (Game.RandomLessThan(100) < 50)
        {
            Game.MsgPrint(upDesc);
            Game.DoCmdSaveGame(true);
            Game.CurrentDepth--;
            Game.NewLevelFlag = true;
            Game.CameFrom = LevelStart.StartRandom;
        }
        else
        {
            Game.MsgPrint(downDesc);
            Game.DoCmdSaveGame(true);
            Game.CurrentDepth++;
            Game.NewLevelFlag = true;
        }
        Game.DoCmdSaveGame(true);
        Game.CurrentDepth++;
        Game.NewLevelFlag = true;
        Game.PlaySound(SoundEffectEnum.TeleportLevel);
    }
}
