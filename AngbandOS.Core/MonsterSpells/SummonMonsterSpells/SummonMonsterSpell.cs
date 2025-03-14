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

    public override void Bind()
    {
        base.Bind();
        MonsterSelector = Game.SingletonRepository.GetNullable<IMonsterSelector>(MonsterSelectorBindingKey);
        FriendlyMonsterSelector = Game.SingletonRepository.GetNullable<IMonsterSelector>(FriendlyMonsterSelectorBindingKey);
    }

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
    /// Returns a monster selector key that is used to specify which type of monster to be summoned; or null, for any monster.  Returns null, by default.
    /// </summary>
    protected virtual string? MonsterSelectorBindingKey => null;

    /// <summary>
    /// Returns a monster filter that is used to specify which type of monster to be summoned or null, for any monster.
    /// </summary>
    protected IMonsterSelector? MonsterSelector { get; private set; }

    /// <summary>
    /// Returns a monster selector key that is used to specify which type of monster to be summoned when a friendly monster is attacking
    /// another monster, or null for any monster.  Returns the monster selector key, by default.
    /// </summary>
    protected virtual string? FriendlyMonsterSelectorBindingKey => MonsterSelectorBindingKey;

    /// <summary>
    /// Returns a monster selector that is used to specify which type of monster to be summoned when a friendly monster is attacking
    /// another monster, or null for any monster.  This property is bound using the <see cref="FriendlyMonsterSelectorBindingKey"/> property during the bind phase.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected IMonsterSelector? FriendlyMonsterSelector { get; private set; }

    /// <summary>
    /// Returns the level of the monster that is summoned; or null, for a level that is the same as the monster that is doing the summoning.
    /// </summary>
    protected virtual int? SummonLevel => null;

    public override void ExecuteOnPlayer(Monster monster)
    {
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        int count = 0;

        for (int k = 0; k < MaximumSummonCount; k++)
        {
            int playerX = Game.MapX.IntValue;
            int playerY = Game.MapY.IntValue;
            int summonLevel = SummonLevel.HasValue ? SummonLevel.Value : monster.Race.Level >= 1 ? monster.Race.Level : 1;

            if (Game.SummonSpecific(playerY, playerX, summonLevel, MonsterSelector?.GetMonsterFilter(monster.Race), true, false))
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
        bool friendly = monster.IsPet;
        int count = 0;

        MonsterRaceFilter? monsterFilter = MonsterSelector?.GetMonsterFilter(monster.Race);
        for (int k = 0; k < 8; k++)
        {
            int summonLevel = SummonLevel.HasValue ? SummonLevel.Value : monster.Race.Level >= 1 ? monster.Race.Level : 1;
            if (friendly)
            {
                if (Game.SummonSpecific(target.MapY, target.MapX, summonLevel, monsterFilter, true, true))
                {
                    count++;
                }
            }
            else
            {
                int playerX = Game.MapX.IntValue;
                int playerY = Game.MapY.IntValue;

                if (Game.SummonSpecific(playerY, playerX, summonLevel, MonsterSelector?.GetMonsterFilter(monster.Race), true, false))
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
