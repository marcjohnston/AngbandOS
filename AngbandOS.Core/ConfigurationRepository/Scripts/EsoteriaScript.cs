// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EsoteriaScript : Script, IScript
{
    private EsoteriaScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Identifies an item.  50% of the time, the item is identified fully.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.Rng.DieRoll(50) > SaveGame.ExperienceLevel)
        {
            SaveGame.IdentifyItem();
        }
        else
        {
            SaveGame.RunScript(nameof(IdentifyFullyScript));
        }
    }
}
