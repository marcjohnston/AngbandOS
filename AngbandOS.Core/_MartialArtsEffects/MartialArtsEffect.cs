// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class MartialArtsEffect : IGetKey
{
    protected readonly Game Game;
    protected MartialArtsEffect(Game game)
    {
        Game = game;
    }

    public Expression StunLevel { get; private set; }

    /// <summary>
    /// Returns an expression for the amount of stun to deliver to the monster with a successful martial arts attack.  Returns 0, by default.
    /// </summary>
    protected virtual string StunLevelExpression { get; } = "0";

    public string GetKey => GetType().Name;

    public void Bind()
    {
        StunLevel = Game.ParseNumericExpression(StunLevelExpression);
    }

    /// <summary>
    /// Returns the total damage from the martial arts effect and the reistance divisor.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    public abstract int Execute(Monster monster, MartialArtsAttack martialArtsAttack, int resistanceToStun);

    protected void DoStun(Monster monster, int resistanceToStun)
    {
        MonsterRace race = monster.Race;
        string monsterName = monster.Name;
        int stunLevel = Game.ComputeIntegerExpression(StunLevel).Value;
        if (stunLevel > 0 && Game.ExperienceLevel.IntValue > Game.DieRoll(race.Level + resistanceToStun + 10))
        {
            Game.MsgPrint(monster.StunLevel != 0 ? $"{monsterName} is more stunned." : $"{monsterName} is stunned.");
            monster.StunLevel += stunLevel;
        }
    }
    public virtual string Key { get; }

}
