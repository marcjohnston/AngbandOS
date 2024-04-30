// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal abstract class MonsterSpell : IGetKey
{
    protected readonly Game Game;
    protected MonsterSpell(Game game) 
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }

    /// <summary>
    /// Returns true, if the spell is an innate ability.  Returns false, by default.  Spells that return true represent spells in the Flags4 flag-set.
    /// </summary>
    public virtual bool IsInnate => false;

    /// <summary>
    /// Returns true, if the spell is an intelligent spell.  Returns false, by default.  Spells that return true represent spells flagged with
    /// IntMask.
    /// </summary>
    public virtual bool IsIntelligent => false;

    /// <summary>
    /// Returns true, if the spell uses acid against its foe.  Returns false, by default.  BreatheAcid, AcidBall and AcidBolt return true.
    /// </summary>
    public virtual bool UsesAcid => false;

    /// <summary>
    /// Returns true, if the spell uses lightning against its foe.  Returns false, by default.  BreatheLightning, LightningBall and LightningBolt return true.
    /// </summary>
    public virtual bool UsesLightning => false;

    /// <summary>
    /// Returns true, if the spell uses fire against its foe.  Returns false, by default.  BreatheFire, FireBall and FireBolt return true.
    /// </summary>
    public virtual bool UsesFire => false;

    /// <summary>
    /// Returns true, if the spell uses cold against its foe.  Returns false, by default.  BreatheCold, ColdBall, ColdBolt and IceBolt return true.
    /// </summary>
    public virtual bool UsesCold => false;

    /// <summary>
    /// Returns true, if the spell uses poison against its foe.  Returns false, by default.  BreathePoison and PoisonBall return true.
    /// </summary>
    public virtual bool UsesPoison => false;

    /// <summary>
    /// Returns true, if the spell uses radiation against its foe.  Returns false, by default.  BreatheRadiation and RadiationBall return true.
    /// </summary>
    public virtual bool UsesRadiation => false;

    /// <summary>
    /// Returns true, if the spell uses nether against its foe.  Returns false, by default.  BreatheNether, NetherBall and NetherBolt return true.
    /// </summary>
    public virtual bool UsesNether => false;

    /// <summary>
    /// Returns true, if the spell uses light against its foe.  Returns false, by default.  BreatheLight returns true.
    /// </summary>
    public virtual bool UsesLight => false;

    /// <summary>
    /// Returns true, if the spell uses darkness against its foe.  Returns false, by default.  BreatheDark and DarkBall returns true.
    /// </summary>
    public virtual bool UsesDarkness => false;

    /// <summary>
    /// Returns true, if the spell uses fear against its foe.  Returns false, by default.  Scare returns true.
    /// </summary>
    public virtual bool UsesFear => false;

    /// <summary>
    /// Returns true, if the spell uses confusion against its foe.  Returns false, by default.  BreatheConfusion and Confuse returns true.
    /// </summary>
    public virtual bool UsesConfusion => false;

    /// <summary>
    /// Returns true, if the spell uses breathe against its foe.  Returns false, by default.
    /// </summary>
    public virtual bool UsesBreathe => false;

    /// <summary>
    /// Returns true, if the spell uses chaos against its foe.  Returns false, by default.  BreatheChaos and ChaosBall return true.
    /// </summary>
    public virtual bool UsesChaos => false;

    /// <summary>
    /// Returns true, if the spell uses disenchantment against its foe.  Returns false, by default.  BreatheDisenchantment returns true.
    /// </summary>
    public virtual bool UsesDisenchantment => false;

    /// <summary>
    /// Returns true, if the spell uses blindess against its foe.  Returns false, by default.  Blindness returns true.
    /// </summary>
    public virtual bool UsesBlindness => false;

    /// <summary>
    /// Returns true, if the spell uses nexus against its foe.  Returns false, by default.  BreatheNexus and TeleportLevel returns true.
    /// </summary>
    public virtual bool UsesNexus => false;

    /// <summary>
    /// Returns true, if the spell uses sound against its foe.  Returns false, by default.  BreatheSound returns true.
    /// </summary>
    public virtual bool UsesSound => false;

    /// <summary>
    /// Returns true, if the spell uses shards its foe.  Returns false, by default.  BreatheShards and ShardBall returns true.
    /// </summary>
    public virtual bool UsesShards => false;

    /// <summary>
    /// Returns true, if the spell can be reflected back from its foe.  Returns false, by default.  ColdBolt,FireBolt, AcidBolt, LightningBolt, 
    /// PoisonBolt, NetherBolt, WaterBolt, ManaBolt, PlasmaBolt, IceBolt, MagicMissile, Arrow1D6, Arrow3D6, Arrow5D6 and Arrow7D6 return true.
    /// </summary>
    public virtual bool CanBeReflected => false;

    /// <summary>
    /// Returns true, if the spell restricts free action against its foe.  Returns false, by default.  Hold and slow returns true.
    /// </summary>
    public virtual bool RestrictsFreeAction => false;

    /// <summary>
    /// Returns true, if the spell drains mana against its foe.  Returns false, by default.  DrainMana returns true.
    /// </summary>
    public virtual bool DrainsMana => false;

    /// <summary>
    /// Returns true, if the spell summons help against its foe.  Returns false, by default.
    /// </summary>
    public virtual bool SummonsHelp => false;

    /// <summary>
    /// Returns true, if the spell provides escape from its foe.  Returns false, by default.  Blink, TeleportSelf, TeleportAway and TeleportLevel return true.
    /// </summary>
    public virtual bool ProvidesEscape => false;

    /// <summary>
    /// Returns true, if the spell heals.  Returns false, by default.  Heal return true.
    /// </summary>
    public virtual bool Heals => false;

    /// <summary>
    /// Returns true, if the spell can attack its foe.  Returns false, by default.
    /// </summary>
    public virtual bool IsAttack => false;

    /// <summary>
    /// Returns true, if the spell is tacticle its foe.  Returns false, by default.  Blink returns true.
    /// </summary>
    public virtual bool IsTactical => false;

    /// <summary>
    /// Returns true, if the spell hastens itself.  Returns false, by default.  Haste returns true.
    /// </summary>
    public virtual bool Hastens => false;

    /// <summary>
    /// Returns true, if the spell annoys its foe.  Returns false, by default.  Shriek, DrainMana, 
    /// MindBlast, BrainSmash, CauseLightWounds, CauseSeriousWounds, CauseCriticalWounds, Scare, 
    /// Blindness, Confuse, Slow, Hold, TeleportTo, Darkness, CreateTraps and Forget return true.
    /// </summary>
    public virtual bool Annoys => false;

    /// <summary>
    /// Returns the message that is rendered to the player, when the spell is being used against the player and the player is blind.
    /// Returns a message that the monster mumbles something, by default.  Returns null, if there is no message to be rendered.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public virtual string? VsPlayerBlindMessage => $"You hear someone mumble.";

    /// <summary>
    /// Returns the message that is rendered to the player, when the spell is targeting the player and the player is not blind.
    /// Returns null, if there is no message to be rendered.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public abstract string? VsPlayerActionMessage(Monster monster);

    /// <summary>
    /// Returns the message that is rendered to the player, when the spell is being used against another monster and the player is blind.
    /// Returns null, if there is no message to be rendered.  By default, the VsPlayerBlindMessage is returned.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public virtual string? VsMonsterUnseenMessage => VsPlayerBlindMessage;

    /// <summary>
    /// Returns the message to be rendered to the player when a monster attacks another monster and the player sees either monster, or null if there
    /// is no message to be rendered.  Returns the VsPlayerActionMessage, by default.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <param name="targetName"></param>
    /// <returns></returns>
    public virtual string? VsMonsterSeenMessage(Monster monster, Monster target) => VsPlayerActionMessage(monster);

    /// <summary>
    /// Returns the characteristics that are learned, when the player experiences or sees the spell.  Returns an empty set, by defaut.
    /// </summary>
    public virtual SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { };

    /// <summary>
    /// Returns true, if the attack on a sleeping monster, wakes the monster.  Returns true, by default.
    /// </summary>
    public virtual bool WakesSleepingMonsters => true;

    /// <summary>
    /// Performs the spell on the player.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="monster"></param>
    public abstract void ExecuteOnPlayer(Monster monster);

    /// <summary>
    /// Performs the spell on a monster.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="monster"></param>
    public abstract void ExecuteOnMonster(Monster monster, Monster target);
}
