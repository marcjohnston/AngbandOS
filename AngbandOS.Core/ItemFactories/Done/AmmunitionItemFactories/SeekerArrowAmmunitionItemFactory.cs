// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SeekerArrowAmmunitionItemFactory : ItemFactory
{
    private SeekerArrowAmmunitionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override int BonusHitRealValueMultiplier => 5;
    public override int BonusDamageRealValueMultiplier => 5;
    public override int BonusDiceRealValueMultiplier => 5;
    protected override string SymbolName => nameof(OpenBracketSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Seeker Arrow";

    public override int Cost => 20;
    public override int DamageDice => 4;
    public override int DamageSides => 4;
    protected override string? DescriptionSyntax => "Seeker Arrow~";
    public override int LevelNormallyFound => 55;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (55, 2)
    };
    public override bool ShowMods => true;
    public override int Weight => 2;
    protected override string ItemClassName => nameof(ArrowsItemClass);
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (500, "5d5-5")
    };

    public override int PackSort => 34;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    /// <summary>
    /// Returns true, for all arrows.
    /// </summary>
    public override bool KindIsGood => true;

    public override int MakeObjectCount => Game.DiceRoll(6, 7);
    protected override string BreakageChanceProbabilityExpression => "25/100";

    public override bool IsWeapon => true;
    public override bool IdentityCanBeSensed => true;
    public override bool GetsDamageMultiplier => true;

    /// <summary>
    /// Ammunition items return a maximum number of 20 items that can be enchanted at one time.
    /// </summary>
    public override int EnchantmentMaximumCount => 20;

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-2}, null, new string[] { nameof(TerribleHit1D5P5BP10BEnchantmentScript), nameof(TerribleDamage1D5P5BP10BEnchantmentScript), nameof(AmmoOfBackbitingEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(PoorHit1D5P5BEnchantmentScript), nameof(PoorDamage1D5P5BEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodHit1D5P5BEnchantmentScript), nameof(GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatHit1D5P5BP10BEnchantmentScript), nameof(GreatDamage1D5P5BP10BEnchantmentScript), nameof(GreatAmmoEnchantmentScript) })
    };

    /// <summary>
    /// Returns true because broken weapons should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Weapons. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;

    public override int BonusArmorClassRealValueMultiplier => 100;
    public override bool IsWearableOrWieldable => true;

    public override bool CanApplySlayingBonus => true;
}