// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

// If it was a knee attack and the monster is male, hit it in the groin
[Serializable]
internal class KneeMartialArtsEffect : MartialArtsEffect
{
    private KneeMartialArtsEffect(Game game) : base(game) { }
    protected override string StunLevelExpression => "7+1d13";
    public override int Execute(Monster monster, MartialArtsAttack martialArtsAttack, int resistanceToStun)
    {
        MonsterRace race = monster.Race;
        string monsterName = monster.Name;
        if (race.Male)
        {
            Game.MsgPrint($"You hit {monsterName} in the groin with your knee!");
        }
        else
        {
            Game.MsgPrint(string.Format(martialArtsAttack.Desc, monsterName));
        }

        // Get damage from the martial arts attack
        int totalDamage = Game.DiceRoll(martialArtsAttack.Dd, martialArtsAttack.Ds);

        // It might be a critical hit
        totalDamage = Game.PlayerCriticalMelee(Game.ExperienceLevel.IntValue * Game.DieRoll(10), martialArtsAttack.MinLevel, totalDamage);
        if (totalDamage + Game.Bonuses.DamageBonus < monster.Health)
        {
            Game.MsgPrint($"{monsterName} moans in agony!");
            resistanceToStun /= 3;
            DoStun(monster, resistanceToStun);
        }
        return totalDamage;
    }
}
