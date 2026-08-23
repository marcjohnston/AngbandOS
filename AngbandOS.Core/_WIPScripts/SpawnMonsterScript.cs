// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.ConsoleElements;
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Scripts;

internal class SpawnMonsterScript : Script, IScript, ICastSpellScript
{
    private SpawnMonsterScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the spawn monster script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        MonsterRace[] monsterRaces = Game.SingletonRepository.Get<MonsterRace>().OrderBy(_monsterRace => _monsterRace.FriendlyName).ToArray();
        ConsoleTableWithRowHighlighting<MonsterRace> table = new ConsoleTableWithRowHighlighting<MonsterRace>(monsterRaces, new (string, Func<MonsterRace, string>)[] {
            ("Name", _monsterRace => _monsterRace.FriendlyName),
            ("Character", _monsterRace => _monsterRace.Symbol.Character.ToString()),
            ("Level", _monsterRace => _monsterRace.LevelFound.ToString()) 
        });
        MonsterRace? selectedMonsterRace = Game.SelectFromConsoleTable<MonsterRace>(table, "Spawn Which Monster?");
        if (selectedMonsterRace is not null)
        {
            (int y, int x) = Game.Scatter(Game.MapY.IntValue, Game.MapX.IntValue, 1);
            bool placed = Game.PlaceMonsterAux(y, x, selectedMonsterRace, false, false, false, false);
            if (!placed)
            {
                Game.MsgPrint("Failed to place monster.");
            }
            else
            {
                Game.RefreshMap.SetChangedFlag();
            }
        }
    }
}
