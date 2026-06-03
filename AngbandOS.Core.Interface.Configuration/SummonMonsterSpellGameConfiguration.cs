namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class SummonMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns true because all summoning magic spells require intelligence.
    /// </summary>
    public virtual bool IsIntelligent { get; set; } = true;

    /// <summary>
    /// Returns true for all summoning magic spells.
    /// </summary>
    public virtual bool SummonsHelp { get; set; } = true;

    /// <summary>
    /// Returns the maximum number of monsters that will be summoned.  Returns 6, by default.
    /// </summary>
    public virtual int MaximumSummonCount { get; set; } = 6;

    /// <summary>
    /// Returns a monster selector key that is used to specify which type of monster to be summoned; or null, for any monster.  Returns null, by default.
    /// </summary>
    public virtual string? MonsterSelectorBindingKey { get; set; } = null;

    /// <summary>
    /// Returns a monster selector key that is used to specify which type of monster to be summoned when a friendly monster is attacking
    /// another monster, or null for any monster.  Returns the monster selector key, by default.
    /// </summary>
    public virtual string? FriendlyMonsterSelectorBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the level of the monster that is summoned; or null, for a level that is the same as the monster that is doing the summoning.
    /// </summary>
    public virtual int? SummonLevel { get; set; } = null;

    /// <summary>
    /// Returns the message to be rendered to the player, when at least one monster has been summoned but the player is blind.  Returns a
    /// message indicating that the player hears many things appear nearby.
    /// </summary>
    public virtual string BlindNonZeroSummonedMessage { get; set; } = "You hear many things appear nearby.";
}
