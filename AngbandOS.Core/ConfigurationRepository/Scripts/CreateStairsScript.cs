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
    private CreateStairsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.CaveValidBold(SaveGame.MapY, SaveGame.MapX))
        {
            SaveGame.MsgPrint("The object resists the spell.");
            return;
        }
        SaveGame.DeleteObject(SaveGame.MapY, SaveGame.MapX);
        if (SaveGame.CurrentDepth <= 0)
        {
            SaveGame.CaveSetFeat(SaveGame.MapY, SaveGame.MapX, SaveGame.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)));
        }
        else if (SaveGame.IsQuest(SaveGame.CurrentDepth) || SaveGame.CurrentDepth >= SaveGame.CurDungeon.MaxLevel)
        {
            SaveGame.CaveSetFeat(SaveGame.MapY, SaveGame.MapX, SaveGame.CurDungeon.Tower ? SaveGame.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)) : SaveGame.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)));
        }
        else if (SaveGame.RandomLessThan(100) < 50)
        {
            SaveGame.CaveSetFeat(SaveGame.MapY, SaveGame.MapX, SaveGame.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)));
        }
        else
        {
            SaveGame.CaveSetFeat(SaveGame.MapY, SaveGame.MapX, SaveGame.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)));
        }
    }
}
