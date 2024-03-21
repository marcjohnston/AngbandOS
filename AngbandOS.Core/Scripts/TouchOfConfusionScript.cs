// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TouchOfConfusionScript : Script, IScript
{
    private TouchOfConfusionScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Sets the HasConfusingTouch property to true.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.HasConfusingTouch)
        {
            SaveGame.MsgPrint("Your hands start glowing.");
            SaveGame.HasConfusingTouch = true;
        }
    }
}
