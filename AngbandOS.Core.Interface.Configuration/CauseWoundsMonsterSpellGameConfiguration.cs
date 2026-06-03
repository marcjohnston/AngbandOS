namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class CauseWoundsMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual bool IsAttack { get; set; } = true;
    public virtual bool Annoys { get; set; } = true;

    public virtual string? VsPlayerBlindMessage { get; set; } = "You hear someone mumble.";

    public virtual string? VsPlayerActionMessage { get; set; } = "{0} points at you and curses.";

    /// <summary>
    /// Returns the roll expression that determines the amount of damage the arrow projectile inflicts.  This expression is parse
    /// to generate the DamageDiceRoll.
    /// </summary>
    public virtual string DamageRollExpression { get; set; }

    /// <summary>
    /// Returns the chance that an item of equipment that the player is wearing will be cursed.
    /// </summary>
    public virtual int CurseEquipmentChance { get; set; }

    /// <summary>
    /// Returns the chance that an item of equipment that the player is wearing will be heavily cursed.
    /// </summary>
    public virtual int HeavyCurseEquipmentChance { get; set; }

    /// <summary>
    /// Returns an additional amount of time the player will bleed.  Returns 0, by default.
    /// </summary>
    public virtual int TimedBleeding { get; set; } = 0;
}
