// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class Stun9p1d9MartialArtsEffect : MartialArtsEffect
{
    private Stun9p1d9MartialArtsEffect(Game game) : base(game) { }
    protected override string StunLevelExpression => "9+1d9";
    public override int Execute(Monster monster, MartialArtsAttack martialArtsAttack, int resistanceToStun)
    {
        string monsterName = monster.Name;
        int stunLevel = Game.ComputeIntegerExpression(StunLevel).Value;
        Game.MsgPrint(string.Format(martialArtsAttack.Desc, monsterName));

        // Get damage from the martial arts attack
        int totalDamage = Game.DiceRoll(martialArtsAttack.Dd, martialArtsAttack.Ds);

        // It might be a critical hit
        totalDamage = Game.PlayerCriticalMelee(Game.ExperienceLevel.IntValue * Game.DieRoll(10), martialArtsAttack.MinLevel, totalDamage);
        if (totalDamage + Game.Bonuses.DamageBonus < monster.Health)
        {
            DoStun(monster, resistanceToStun);
        }
        return totalDamage;
    }
}
