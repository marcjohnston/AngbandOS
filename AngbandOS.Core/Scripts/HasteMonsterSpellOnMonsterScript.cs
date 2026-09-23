// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class HasteMonsterSpellOnMonsterScript : Script, IScriptMonsterMonster
{
    private HasteMonsterSpellOnMonsterScript(Game game) : base(game) { }
    public void ExecuteScriptMonsterMonster(Monster monster, Monster target)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seen = !blind && monster.IsVisible;
        MonsterRace targetRace = target.Race;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            if (seen)
            {
                Game.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            if (seen)
            {
                Game.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 2;
        }
    }
}
