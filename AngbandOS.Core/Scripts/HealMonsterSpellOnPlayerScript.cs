// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class HealMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private HealMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        string monsterPossessive = monster.PossessiveName;
        string monsterName = monster.Name;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool seenByPlayer = !playerIsBlind && monster.IsVisible;

        monster.Health += monsterLevel * 6;
        if (monster.Health >= monster.MaxHealth)
        {
            monster.Health = monster.MaxHealth;
            Game.MsgPrint(seenByPlayer ? $"{monsterName} looks completely healed!" : $"{monsterName} sounds completely healed!");
        }
        else
        {
            Game.MsgPrint(seenByPlayer ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
        }
        if (monster.FearLevel != 0)
        {
            monster.FearLevel = 0;
            Game.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
        }
    }
}
