// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DrainManaMonsterSpellOnMonsterScript : Script, IScriptMonsterMonster
{
    private DrainManaMonsterSpellOnMonsterScript(Game game) : base(game) { }
    public void ExecuteScriptMonsterMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string monsterName = monster.Name;
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        bool seeBoth = seen && seeTarget;
        MonsterRace targetRace = target.Race;

        int r1 = (base.Game.DieRoll(rlev) / 2) + 1;
        if (monster.Health < monster.MaxHealth)
        {
            if (targetRace.Spells.Length == 0)
            {
                if (seeBoth)
                {
                    Game.MsgPrint($"{targetName} is unaffected!");
                }
            }
            else
            {
                monster.Health += 6 * r1;
                if (monster.Health > monster.MaxHealth)
                {
                    monster.Health = monster.MaxHealth;
                }
                if (seen)
                {
                    Game.MsgPrint($"{monsterName} appears healthier.");
                }
            }
        }
    }
}
