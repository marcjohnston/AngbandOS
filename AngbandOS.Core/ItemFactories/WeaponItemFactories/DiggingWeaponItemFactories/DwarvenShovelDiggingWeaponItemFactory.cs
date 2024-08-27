// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DwarvenShovelDiggingWeaponItemFactory : WeaponItemFactory
{
    private DwarvenShovelDiggingWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Dwarven Shovel";

    public override int Cost => 200;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    protected override string? DescriptionSyntax => "Dwarven Shovel~";
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override int InitialBonusTunnel => 3;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 120;

    /// <summary>
    /// Returns the digger inventory slot for shovels.
    /// </summary>
    public override int WieldSlot => InventorySlot.Digger;
    protected override string ItemClassName => nameof(DiggersItemClass);
    public override bool CanTunnel => true;
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-2}, null, new string[] { nameof(TerribleAmmoEnchantmentScript), nameof(TerribleDiggerEnchantmentScript), nameof(PoorDiggerEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {-1}, null, new string[] { nameof(PoorHit1D5P5BEnchantmentScript), nameof(PoorDamage1D5P5BEnchantmentScript), nameof(PoorDiggerEnchantmentScript), nameof(CursedWeaponEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodHit1D5P5BEnchantmentScript), nameof(GoodDamage1D5P5BEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatHit1D5P5BP10BEnchantmentScript), nameof(GreatDamage1D5P5BP10BEnchantmentScript), nameof(GreatAmmoEnchantmentScript) })
    };
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(DiggerInventorySlot));
    public override int PackSort => 31;
    public override bool GetsDamageMultiplier => true;
}
