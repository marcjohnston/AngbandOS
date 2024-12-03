// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ShovelDiggingWeaponItemFactory : WeaponItemFactory
{
    private ShovelDiggingWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Shovel";

    public override int Cost => 10;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    protected override string? DescriptionSyntax => "Shovel~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 16)
    };
    public override int InitialBonusTunnel => 1;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 60;

    protected override string ItemClassBindingKey => nameof(DiggersItemClass);
    public override bool CanTunnel => true;
    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (100, "3d5-3")
    };

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-2}, null, new string[] { nameof(TerribleHit1D5P5BP10BEnchantmentScript), nameof(TerribleDamage1D5P5BP10BEnchantmentScript), nameof(TerribleDiggerEnchantmentScript), nameof(TerribleTunnelEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(PoorHit1D5P5BEnchantmentScript), nameof(PoorDamage1D5P5BEnchantmentScript), nameof(TerribleTunnelEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodHit1D5P5BEnchantmentScript), nameof(GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatHit1D5P5BP10BEnchantmentScript), nameof(GreatDamage1D5P5BP10BEnchantmentScript), nameof(GreatAmmoEnchantmentScript) })
    };
    protected override string[] WieldSlotBindingKeys => new string[] { nameof(DiggerWieldSlot) };
    public override int PackSort => 31;
    public override bool GetsDamageMultiplier => true;
}
