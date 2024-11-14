// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal abstract class SummonMonsterSpell : MonsterSpell
{
    protected SummonMonsterSpell(Game game) : base(game) { }
    /// <summary>
    /// Returns true because all summoning magic spells require intelligence.
    /// </summary>
    public override bool IsIntelligent => true;

    /// <summary>
    /// Returns true for all summoning magic spells.
    /// </summary>
    public override bool SummonsHelp => true;

    /// <summary>
    /// Returns the maximum number of monsters that will be summoned.  Returns 6, by default.
    /// </summary>
    protected virtual int MaximumSummonCount => 6;

    /// <summary>
    /// Returns a monster filter that is used to specify which type of monster to be summoned or null, for any monster.
    /// </summary>
    protected abstract IMonsterFilter? MonsterSelector(Monster monster);

    /// <summary>
    /// Returns a monster selector that is used to specify which type of monster to be summoned when a friendly monster is attacking
    /// another monster, or null for any monster.  Returns the same monster selector as the MonsterSelector, by default.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected virtual IMonsterFilter? FriendlyMonsterSelector(Monster monster) => MonsterSelector(monster);

    protected virtual int SummonLevel(Monster monster) => monster.Race.Level >= 1 ? monster.Race.Level : 1;

    /// <summary>
    /// Summons non-friendly monsters.  Can be overrideen for special summoning needs.  Only the SummonReaver needs to call a special method.
    /// </summary>
    /// <returns></returns>
    protected virtual bool Summon(Game game, Monster monster)
    {
        int playerX = game.MapX.IntValue;
        int playerY = game.MapY.IntValue;

        return game.SummonSpecific(playerY, playerX, SummonLevel(monster), MonsterSelector(monster));
    }

    public override void ExecuteOnPlayer(Monster monster)
    {
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        int count = 0;

        for (int k = 0; k < MaximumSummonCount; k++)
        {
            if (Summon(Game, monster))
            {
                count++;
            }
        }
        if (playerIsBlind && count != 0)
        {
            Game.MsgPrint("You hear many things appear nearby.");
        }
    }

    /// <summary>
    /// Returns the message to be rendered to the player, when at least one monster has been summoned but the player is blind.  Returns a
    /// message indicating that the player hears many things appear nearby.
    /// </summary>
    protected virtual string BlindNonZeroSummonedMessage => "You hear many things appear nearby.";

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        bool friendly = monster.SmFriendly;
        int count = 0;

        for (int k = 0; k < 8; k++)
        {
            if (friendly)
            {
                if (Game.SummonSpecificFriendly(target.MapY, target.MapX, SummonLevel(monster), FriendlyMonsterSelector(monster), true))
                {
                    count++;
                }
            }
            else
            {
                if (Summon(Game, monster))
                {
                    count++;
                }
            }
        }
        if (playerIsBlind && count != 0)
        {
            Game.MsgPrint(BlindNonZeroSummonedMessage);
        }
    }
}
