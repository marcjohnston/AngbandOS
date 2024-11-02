// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GlaivePolearmWeaponItemFactory : WeaponItemFactory
{
    private GlaivePolearmWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ForwardSlashSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Glaive";

    public override int Cost => 363;
    public override int DamageDice => 2;
    public override int DamageSides => 6;
    protected override string? DescriptionSyntax => "Glaive~";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 190;
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    protected override string ItemClassName => nameof(PolearmsItemClass);
    public override bool HatesFire => true;
    public override int PackSort => 29;
    public override bool HatesAcid => true;

    public override bool CanApplyBlessedArtifactBias => true;

    /// <summary>
    /// Returns the melee weapon inventory slot for melee weapons.
    /// </summary>
    public override int WieldSlot => InventorySlot.MeleeWeapon;

    public override bool GetsDamageMultiplier => true;

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-2}, null, new string[] { nameof(TerribleHit1D5P5BP10BEnchantmentScript), nameof(TerribleDamage1D5P5BP10BEnchantmentScript), nameof(TerribleMeleeWeaponEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(PoorHit1D5P5BEnchantmentScript), nameof(PoorDamage1D5P5BEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodHit1D5P5BEnchantmentScript), nameof(GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatHit1D5P5BP10BEnchantmentScript), nameof(GreatDamage1D5P5BP10BEnchantmentScript), nameof(GreatMeleeWeaponEnchantmentScript) })
    };
}
