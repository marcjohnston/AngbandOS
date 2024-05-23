// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CestiGlovesArmorItemFactory : GlovesArmorItemFactory
{
    private CestiGlovesArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Set of Cesti";

    public override int ArmorClass => 5;
    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "& Set~ of Cesti";
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int Weight => 40;
    protected override string ItemClassName => nameof(GlovesItemClass);

    /// <summary>
    /// Returns the hands inventory slots for gloves.
    /// </summary>
    public override int WieldSlot => InventorySlot.Hands;
    public override int PackSort => 26;
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(HandsInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gloves;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

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
    public override bool IsWearable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => BonusArmorClass >= 0;
}
