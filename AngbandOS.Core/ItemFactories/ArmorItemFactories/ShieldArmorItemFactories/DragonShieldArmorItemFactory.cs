// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonShieldArmorItemFactory : ArmorItemFactory
{
    private DragonShieldArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Dragon Shield";

    /// <summary>
    /// Returns a treasure rating of 5 for a shield of dragon scale mail.
    /// </summary>
    public override int TreasureRating => 5;
    public override int ArmorClass => 8;
    public override int Cost => 10000;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    protected override string? DescriptionSyntax => "Dragon Shield~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (80, 4)
    };
    public override int BonusArmorClass => 10;
    public override int Weight => 100;

    /// <summary>
    /// Returns the arm inventory slot for shields.
    /// </summary>
    public override int WieldSlot => InventorySlot.Arm;

    protected override string ItemClassName => nameof(ShieldsItemClass);
    public override int PackSort => 23;
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
        (new int[] { -2 }, null, new string[] { nameof(TerribleShieldEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorShieldEnchantmentScript) }),
        (null, null, new string[] { nameof(DragonResistanceEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodShieldEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatShieldEnchantmentScript) })
    };
}
