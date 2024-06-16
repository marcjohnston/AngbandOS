// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal abstract class FixedArtifact : ItemAdditiveBundle
{
    protected FixedArtifact(Game game) : base(game) { }

    public override void Bind()
    {
        base.Bind();
        BaseItemFactory = Game.SingletonRepository.Get<ItemFactory>(BaseItemFactoryName);

        BonusStrength = Game.ParseNullableRollExpression(BonusStrengthRollExpression);
        BonusIntelligence = Game.ParseNullableRollExpression(BonusIntelligenceRollExpression);
        BonusWisdom = Game.ParseNullableRollExpression(BonusWisdomRollExpression);
        BonusDexterity = Game.ParseNullableRollExpression(BonusDexterityRollExpression);
        BonusConstitution = Game.ParseNullableRollExpression(BonusConstitutionRollExpression);
        BonusCharisma = Game.ParseNullableRollExpression(BonusCharismaRollExpression);
        BonusStealth = Game.ParseNullableRollExpression(BonusStealthRollExpression);
        BonusSearch = Game.ParseNullableRollExpression(BonusSearchRollExpression);
        BonusInfravision = Game.ParseNullableRollExpression(BonusInfravisionRollExpression);
        BonusTunnel = Game.ParseNullableRollExpression(BonusTunnelRollExpression);
        BonusAttacks = Game.ParseNullableRollExpression(BonusAttacksRollExpression);
        BonusSpeed = Game.ParseNullableRollExpression(BonusSpeedRollExpression);
    }

/// <summary>
/// Represents the quantity of this artifact currently in existence.  
/// </summary>
public int CurNum = 0; // TODO: This property should graduate into an ItemFactory as the Count property.

    /// <summary>
    /// Returns the multipler to use when being used to kill a dragon.  The SwordOfLightning returns a 3.  All other weapons return 1.
    /// </summary>
    public virtual int KillDragonMultiplier => 1;

    /// <summary>
    /// Allows the fixed artifact to apply resistances and power as needed.  Does nothing, by default.
    /// </summary>
    /// <returns></returns>
    public virtual void ApplyResistances(Item item) { }

    protected abstract string BaseItemFactoryName { get; }

    /// <summary>
    /// Returns the item factory that acts as the base item for fixed artifacts of this type.
    /// </summary>
    public ItemFactory BaseItemFactory { get; private set; }

    /// <summary>
    /// Returns a 1-in-chance value of the weapon doing extra vorpal damage.  Does not affect non-vorpal cutting weapons.  Default to a 1-in-6 chance.
    /// </summary>
    public virtual int VorpalExtraDamage1InChance => 6;

    public virtual bool IsVorpalBlade => false;

    /// <summary>
    /// Returns a 1-in-chance value of the weapon doing extra vorpal attacks. Does not affect non-vorpal cutting weapons.  Default to a 1-in-4 chance.
    /// </summary>
    public virtual int VorpalExtraAttacks1InChance => 4;

    public virtual ColorEnum Color => ColorEnum.White;
    public abstract string Name { get; }

    public abstract int Ac { get; }

    public override int TreasureRating => 10;

    public abstract int Cost { get; }

    public abstract int Dd { get; }

    public abstract int Ds { get; }

    public abstract string FriendlyName { get; }

    public virtual bool HasOwnType => false;

    public abstract int Level { get; }

    protected virtual string? BonusStrengthRollExpression => null;
    protected virtual string? BonusIntelligenceRollExpression => null;
    protected virtual string? BonusWisdomRollExpression => null;
    protected virtual string? BonusDexterityRollExpression => null;
    protected virtual string? BonusConstitutionRollExpression => null;
    protected virtual string? BonusCharismaRollExpression => null;
    protected virtual string? BonusStealthRollExpression => null;
    protected virtual string? BonusSearchRollExpression => null;
    protected virtual string? BonusInfravisionRollExpression => null;
    protected virtual string? BonusTunnelRollExpression => null;
    protected virtual string? BonusAttacksRollExpression => null;
    protected virtual string? BonusSpeedRollExpression => null;

    public Roll? BonusStrength { get; private set; } = null;
    public Roll? BonusIntelligence { get; private set; } = null;
    public Roll? BonusWisdom { get; private set; } = null;
    public Roll? BonusDexterity { get; private set; } = null;
    public Roll? BonusConstitution { get; private set; } = null;
    public Roll? BonusCharisma { get; private set; } = null;
    public Roll? BonusStealth { get; private set; } = null;
    public Roll? BonusSearch { get; private set; } = null;
    public Roll? BonusInfravision { get; private set; } = null;
    public Roll? BonusTunnel { get; private set; } = null;
    public Roll? BonusAttacks { get; private set; } = null;
    public Roll? BonusSpeed { get; private set; } = null;

    public abstract int Rarity { get; }

    public abstract int ToA { get; }

    public abstract int ToD { get; }

    public abstract int ToH { get; }

    public abstract int Weight { get; }
}
