// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EvocationScript : Script, IScript
{
    private EvocationScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Displels, turns and banishs monsters with damage of the player experience * 4.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.DispelMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.TurnMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.BanishMonsters(SaveGame.ExperienceLevel * 4);
    }
}
