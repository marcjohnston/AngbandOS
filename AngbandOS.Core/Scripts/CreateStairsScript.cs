// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CreateStairsScript : Script, IScript
{
    private CreateStairsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.CaveValidBold(Game.MapY.IntValue, Game.MapX.IntValue))
        {
            Game.MsgPrint("The object resists the spell.");
            return;
        }
        Game.DeleteObject(Game.MapY.IntValue, Game.MapX.IntValue);
        if (Game.CurrentDepth <= 0)
        {
            Game.CaveSetFeat(Game.MapY.IntValue, Game.MapX.IntValue, Game.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)));
        }
        else if (Game.IsQuest(Game.CurrentDepth) || Game.CurrentDepth >= Game.CurDungeon.MaxLevel)
        {
            Game.CaveSetFeat(Game.MapY.IntValue, Game.MapX.IntValue, Game.CurDungeon.Tower ? Game.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)) : Game.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)));
        }
        else if (Game.RandomLessThan(100) < 50)
        {
            Game.CaveSetFeat(Game.MapY.IntValue, Game.MapX.IntValue, Game.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)));
        }
        else
        {
            Game.CaveSetFeat(Game.MapY.IntValue, Game.MapX.IntValue, Game.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)));
        }
    }
}
