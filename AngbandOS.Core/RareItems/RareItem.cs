// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

/// <summary>
/// Represents additional characteristics that are applied to items.  These characteristics affect:
/// 1. Description - The item description is enhanced
/// 2. Item Characteristics - Rare items participate in the IItemCharacteristics interface and the rare item characteristics are merged with the original item.
/// 3. Application of Magic - Items with rare item characteristics 
/// </summary>
[Serializable]
internal abstract class RareItem : ItemAdditiveBundle
{
    protected RareItem(Game game) : base(game) { }

    public override void Bind()
    {
        base.Bind();
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

    public virtual void ApplyMagic(Item item) { }

    /// <summary>
    /// Returns the value of the rare item.  When this value is 0, the item is considered worthless regardless of the value of the original item and the
    /// item is considered broken; otherwise this value is added to the value of the original item.
    /// </summary>
    public virtual int? AdditiveBundleValue => null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    public virtual string? FriendlyName => null;

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

    /// <summary>
    /// Returns a maximum value for a random amount of additional strength when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item.  Returns 0, by default.
    /// </summary>
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

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusArmorClass when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToA => 0;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusDamage when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToD => 0;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusToHit when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToH => 0;
}
