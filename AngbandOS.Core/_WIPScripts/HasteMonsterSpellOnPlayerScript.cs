// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HasteMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private HasteMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        string monsterName = monster.Name;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            Game.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            Game.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 2;
        }
    }
}
