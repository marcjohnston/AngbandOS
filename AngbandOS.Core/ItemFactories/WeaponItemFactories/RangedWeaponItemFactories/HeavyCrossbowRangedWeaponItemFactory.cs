// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HeavyCrossbowRangedWeaponItemFactory : RangedWeaponItemFactory
{
    private HeavyCrossbowRangedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBracketSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Heavy Crossbow";

    protected override string ItemClassName => nameof(CrossbowItemClass);
    public override int Cost => 300;
    protected override string? DescriptionSyntax => "Heavy Crossbow~";
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 200;
    public override int MissileDamageMultiplier => 4;
    protected override string[]? AmmunitionItemFactoryNames => new string[]
    {
        nameof(SteelBoltAmmunitionItemFactory),
        nameof(SeekerBoltAmmunitionItemFactory)
    };

    /// <summary>
    /// Returns the ranged weapon inventory slot for bows.
    /// </summary>
    public override int WieldSlot => InventorySlot.RangedWeapon;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override bool IsRangedWeapon => true;

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
   {
        (new int[] {-2}, null, new string[] { nameof(TerribleHit1D5P5BP10BEnchantmentScript), nameof(TerribleDamage1D5P5BP10BEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(PoorHit1D5P5BEnchantmentScript), nameof(PoorDamage1D5P5BEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodHit1D5P5BEnchantmentScript), nameof(GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatHit1D5P5BP10BEnchantmentScript), nameof(GreatDamage1D5P5BP10BEnchantmentScript), nameof(GreatRangedWeaponEnchantmentScript) })
   };

    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(RangedWeaponInventorySlot));
    public override bool CanApplyBlowsBonus => true;

    public override int PackSort => 32;

    public override bool CanProjectArrows => true;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override bool CanApplyArtifactBiasSlaying => false;

}
