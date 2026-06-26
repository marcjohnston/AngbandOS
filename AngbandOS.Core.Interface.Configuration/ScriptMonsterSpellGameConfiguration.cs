namespace AngbandOS.Core.Interface.Configuration;

public class ScriptMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual (string, string) KnowledgeAction { get; set; }

    /// <summary>
    /// Returns true, if the spell is an innate ability.  Returns false, by default.  Spells that return true represent spells in the Flags4 flag-set.
    /// </summary>
    public virtual bool IsInnate { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell is an intelligent spell.  Returns false, by default.  Spells that return true represent spells flagged with
    /// IntMask.
    /// </summary>
    public virtual bool IsIntelligent { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses acid against its foe.  Returns false, by default.  BreatheAcid, AcidBall and AcidBolt return true.
    /// </summary>
    public virtual bool UsesAcid { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses lightning against its foe.  Returns false, by default.  BreatheLightning, LightningBall and LightningBolt return true.
    /// </summary>
    public virtual bool UsesLightning { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses fire against its foe.  Returns false, by default.  BreatheFire, FireBall and FireBolt return true.
    /// </summary>
    public virtual bool UsesFire { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses cold against its foe.  Returns false, by default.  BreatheCold, ColdBall, ColdBolt and IceBolt return true.
    /// </summary>
    public virtual bool UsesCold { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses poison against its foe.  Returns false, by default.  BreathePoison and PoisonBall return true.
    /// </summary>
    public virtual bool UsesPoison { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses radiation against its foe.  Returns false, by default.  BreatheRadiation and RadiationBall return true.
    /// </summary>
    public virtual bool UsesRadiation { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses nether against its foe.  Returns false, by default.  BreatheNether, NetherBall and NetherBolt return true.
    /// </summary>
    public virtual bool UsesNether { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses light against its foe.  Returns false, by default.  BreatheLight returns true.
    /// </summary>
    public virtual bool UsesLight { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses darkness against its foe.  Returns false, by default.  BreatheDark and DarkBall returns true.
    /// </summary>
    public virtual bool UsesDarkness { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses fear against its foe.  Returns false, by default.  Scare returns true.
    /// </summary>
    public virtual bool UsesFear { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses confusion against its foe.  Returns false, by default.  BreatheConfusion and Confuse returns true.
    /// </summary>
    public virtual bool UsesConfusion { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses breathe against its foe.  Returns false, by default.
    /// </summary>
    public virtual bool UsesBreathe { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses chaos against its foe.  Returns false, by default.  BreatheChaos and ChaosBall return true.
    /// </summary>
    public virtual bool UsesChaos { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses disenchantment against its foe.  Returns false, by default.  BreatheDisenchantment returns true.
    /// </summary>
    public virtual bool UsesDisenchantment { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses blindess against its foe.  Returns false, by default.  Blindness returns true.
    /// </summary>
    public virtual bool UsesBlindness { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses nexus against its foe.  Returns false, by default.  BreatheNexus and TeleportLevel returns true.
    /// </summary>
    public virtual bool UsesNexus { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses sound against its foe.  Returns false, by default.  BreatheSound returns true.
    /// </summary>
    public virtual bool UsesSound { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell uses shards its foe.  Returns false, by default.  BreatheShards and ShardBall returns true.
    /// </summary>
    public virtual bool UsesShards { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell can be reflected back from its foe.  Returns false, by default.  ColdBolt,FireBolt, AcidBolt, LightningBolt, 
    /// PoisonBolt, NetherBolt, WaterBolt, ManaBolt, PlasmaBolt, IceBolt, MagicMissile, Arrow1D6, Arrow3D6, Arrow5D6 and Arrow7D6 return true.
    /// </summary>
    public virtual bool CanBeReflected { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell restricts free action against its foe.  Returns false, by default.  Hold and slow returns true.
    /// </summary>
    public virtual bool RestrictsFreeAction { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell drains mana against its foe.  Returns false, by default.  DrainMana returns true.
    /// </summary>
    public virtual bool DrainsMana { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell summons help against its foe.  Returns false, by default.
    /// </summary>
    public virtual bool SummonsHelp { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell provides escape from its foe.  Returns false, by default.  Blink, TeleportSelf, TeleportAway and TeleportLevel return true.
    /// </summary>
    public virtual bool ProvidesEscape { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell heals.  Returns false, by default.  Heal return true.
    /// </summary>
    public virtual bool Heals { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell can attack its foe.  Returns true, by default.
    /// </summary>
    public virtual bool IsAttack { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell is tacticle its foe.  Returns false, by default.  Blink returns true.
    /// </summary>
    public virtual bool IsTactical { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell hastens itself.  Returns false, by default.  Haste returns true.
    /// </summary>
    public virtual bool Hastens { get; set; } = false;

    /// <summary>
    /// Returns true, if the spell annoys its foe.  Returns true, by default.  Shriek, DrainMana, 
    /// MindBlast, BrainSmash, CauseLightWounds, CauseSeriousWounds, CauseCriticalWounds, Scare, 
    /// Blindness, Confuse, Slow, Hold, TeleportTo, Darkness, CreateTraps and Forget return true.
    /// </summary>
    public virtual bool Annoys { get; set; } = false;

    /// <summary>
    /// Returns the message that is rendered to the player, when the spell is being used against the player and the player is blind.
    /// Returns a message that the monster mumbles something, by default.  Returns null, if there is no message to be rendered.
    /// {0} - The monster name (monster.Name)
    /// {1} - The genderized possessive name of the monster ... (e.g. "his", if visible) or (e.g. "its", if invisible) 
    /// {2} - The name of the monsters kin.  (e.g. uniques will use "minions" and non-uniques will use "kin" because uniques have no kin)
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public virtual string? VsPlayerBlindMessage { get; set; } = "You hear someone mumble.";

    /// <summary>
    /// Returns the message that is rendered to the player, when the spell is targeting the player, the player is not blind and the monster is visible.  Returns null, if there is no message to be rendered.
    /// Returns null, by default.  The message supports the following macros:
    /// {0} - The monster name (monster.Name)
    /// {1} - The genderized possessive name of the monster ... (e.g. "his", if visible) or (e.g. "its", if invisible) 
    /// {2} - The name of the monsters kin.  (e.g. uniques will use "minions" and non-uniques will use "kin" because uniques have no kin)
    /// </summary>
    public virtual string? VsPlayerActionMessage { get; set; } = null;

    /// <summary>
    /// Returns the message that is rendered to the player, when the spell is targeting the player, the player is not blind and the monster is not visible.  Returns null, if there is no message to be rendered.
    /// Returns the <see cref="VsPlayerActionMessage"/>, by default.  The message supports the following macros:
    /// {0} - The monster name (monster.Name)
    /// {1} - The genderized possessive name of the monster ... (e.g. "his", if visible) or (e.g. "its", if invisible) 
    /// {2} - The name of the monsters kin.  (e.g. uniques will use "minions" and non-uniques will use "kin" because uniques have no kin)
    /// </summary>
    public virtual string? VsPlayerActionMessageOnInvisibleMonster { get; set; }

    /// <summary>
    /// Returns the message that is rendered to the player, when the spell is being used against another monster and the player is blind.
    /// Returns null, if there is no message to be rendered.  By default, the VsPlayerBlindMessage is returned.
    /// {0} - The monster name (monster.Name)
    /// {1} - The genderized possessive name of the monster ... (e.g. "his", if visible) or (e.g. "its", if invisible) 
    /// {2} - The name of the monsters kin.  (e.g. uniques will use "minions" and non-uniques will use "kin" because uniques have no kin)
    /// {3} - The name of the monster that the attack targeted.
    /// {4} - The formal possessive name of the target monster.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public virtual string? VsMonsterUnseenMessage { get; set; } = null;

    /// <summary>
    /// Returns the message to be rendered to the player when a monster attacks another monster and the player sees either monster, or null if there
    /// is no message to be rendered.  Returns the VsPlayerActionMessage, by default.
    /// {0} - The monster name (monster.Name)
    /// {1} - The generalized possessive name of the monster ... (e.g. "his", if visible) or (e.g. "its", if invisible) 
    /// {2} - The name of the monsters kin.  (e.g. uniques will use "minions" and non-uniques will use "kin" because uniques have no kin)
    /// {3} - The name of the monster that the attack targeted.
    /// {4} - The formal possessive name of the target monster.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <param name="targetName"></param>
    /// <returns></returns>
    public virtual string? VsMonsterSeenMessage { get; set; } = null;

    /// <summary>
    /// Returns the keys for the <see cref="SpellResistantDetection"/> characteristics that are learned, when the player experiences or sees the spell.  Returns an empty set, by defaut.  This
    /// property is used to bind the <see cref="SmartLearn"/> property during the binding phase.
    /// </summary>
    public virtual string[]? SmartLearnSpellResistantDetectionKeys { get; set; } = null;

    /// Returns true, if the attack on a sleeping monster, wakes the monster.  Returns true, by default.
    /// </summary>
    public virtual bool WakesSleepingMonsters { get; set; } = true;

    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on the player. If null, no script will be executed.
    /// </summary>
    public virtual string? ExecuteOnPlayerScriptBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on a monster. If null, no script will be executed.
    /// </summary>
    public virtual string? ExecuteOnMonsterScriptBindingKey { get; set; } = null;
}
