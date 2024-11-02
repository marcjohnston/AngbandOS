// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HardLeatherCapHelmArmorItemFactory : ArmorItemFactory
{
    private HardLeatherCapHelmArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Hard Leather Cap";

    public override int ArmorClass => 2;
    public override int Cost => 12;
    protected override string? DescriptionSyntax => "Hard Leather Cap~";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int Weight => 15;

    /// <summary>
    /// Returns the head inventory slot for helms.
    /// </summary>
    public override int WieldSlot => InventorySlot.Head;

    protected override string ItemClassName => nameof(HelmsItemClass);
    public override int PackSort => 25;
    public override bool HatesAcid => true;

    public override bool CanReflectBoltsAndArrows => true;

    /// <summary>
    /// Returns true because broken armor should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Armor. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
    public override bool IsArmor => true;
    public override bool IdentityCanBeSensed => true;
    public override bool IsWearableOrWieldable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => BonusArmorClass >= 0;
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleHelmEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorHelmEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodHelmEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatHelmEnchantmentScript) })
    };
}
