// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class IronHelmArmorItemFactory : HelmArmorItemFactory
{
    private IronHelmArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Iron Helm";

    public override int ArmorClass => 5;
    public override int Cost => 75;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    public override string FriendlyName => "& Iron Helm~";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 75;

    /// <summary>
    /// Returns the head inventory slot for helms.
    /// </summary>
    public override int WieldSlot => InventorySlot.Head;

    protected override string ItemClassName => nameof(HelmsItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(HeadInventorySlot));
    public override int PackSort => 25;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Helm;
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
    public override bool IsWearable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => BonusArmorClass >= 0;
}
