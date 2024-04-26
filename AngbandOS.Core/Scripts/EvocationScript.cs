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
    private EvocationScript(Game game) : base(game) { }

    /// <summary>
    /// Displels, turns and banishs monsters with damage of the player experience * 4.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.DispelMonsters(Game.ExperienceLevel.IntValue * 4);
        Game.TurnMonsters(Game.ExperienceLevel.IntValue * 4);
        Game.RunScriptInt(nameof(BanishMonsters4xScript), Game.ExperienceLevel.IntValue * 4);
    }
}
