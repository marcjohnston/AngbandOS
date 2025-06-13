// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

// If it was an ankle kick and the monster has legs, slow it
[Serializable]
internal class SlowMartialArtsEffect : MartialArtsEffect
{
    private SlowMartialArtsEffect(Game game) : base(game) { }
    public override int Execute(Monster monster, MartialArtsAttack martialArtsAttack, int resistanceToStun)
    {
        // Check to ensure the monster is not stationary and has legs.
        MonsterRace race = monster.Race;
        string monsterName = monster.Name;
        if (!race.NeverMove && race.HasLegs)
        {
            Game.MsgPrint($"You kick {monsterName} in the ankle.");
        }
        else
        {
            Game.MsgPrint(string.Format(martialArtsAttack.Desc, monsterName));
        }

        // Get damage from the martial arts attack
        int totalDamage = Game.DiceRoll(martialArtsAttack.Dd, martialArtsAttack.Ds);

        // It might be a critical hit
        totalDamage = Game.PlayerCriticalMelee(Game.ExperienceLevel.IntValue * Game.DieRoll(10), martialArtsAttack.MinLevel, totalDamage);
        if (totalDamage + Game.DamageBonus < monster.Health)
        {
            if (!race.Unique && Game.DieRoll(Game.ExperienceLevel.IntValue) > race.Level && monster.Speed > 60)
            {
                Game.MsgPrint($"{monsterName} starts limping slower.");
                monster.Speed -= 10;
            }
            DoStun(monster, resistanceToStun);
        }
        return totalDamage;
    }
}
