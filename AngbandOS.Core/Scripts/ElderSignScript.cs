// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ElderSignScript : Script, IScript
{
    private ElderSignScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GridOpenNoItem(SaveGame.MapY, SaveGame.MapX))
        {
            SaveGame.MsgPrint("The object resists the spell.");
            return;
        }
        SaveGame.CaveSetFeat(SaveGame.MapY, SaveGame.MapX, SaveGame.SingletonRepository.Tiles.Get(nameof(ElderSignSigilTile)));
    }
}
