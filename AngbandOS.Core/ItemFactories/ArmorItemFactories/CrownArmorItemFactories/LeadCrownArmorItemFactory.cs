// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LeadCrownArmorItemFactory : ArmorItemFactory
{
    private LeadCrownArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Lead Crown";

    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    protected override string? DescriptionSyntax => "Lead Crown~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 44;
    public override int Weight => 20;
    /// <summary>
    /// Returns the head inventory slot, for crowns.
    /// </summary>
    public override int WieldSlot => InventorySlot.Head;

    protected override string ItemClassName => nameof(CrownsItemClass);


    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleCrownEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorCrownEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodCrownEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatCrownEnchantmentScript) })
    };
    
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(HeadInventorySlot));
    public override bool HatesAcid => true;

    public override int PackSort => 24;

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
}
