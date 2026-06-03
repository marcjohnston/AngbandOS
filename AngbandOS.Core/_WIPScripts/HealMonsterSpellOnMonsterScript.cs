// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HealMonsterSpellOnMonsterScript : Script, IScriptMonsterMonster
{
    private HealMonsterSpellOnMonsterScript(Game game) : base(game) { }
    public void ExecuteScriptMonsterMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string monsterName = monster.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seen = !blind && monster.IsVisible;

        monster.Health += rlev * 6;
        if (monster.Health >= monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
            Game.MsgPrint(seen ? $"{monsterName} looks completely healed!" : $"{monsterName} sounds completely healed!");
        }
        else
        {
            Game.MsgPrint(seen ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
        }
        if (monster.FearLevel != 0)
        {
            monster.FearLevel = 0;
            if (seen)
            {
                Game.MsgPrint($"{monsterName} recovers {monster.PossessiveName} courage.");
            }
        }
    }
}
