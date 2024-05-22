// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GoldDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private GoldDragonScaleMailArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string ActivationScriptName => nameof(BreatheSoundScript);
    public override int ActivationRechargeTime => Game.RandomLessThan(450) + 450;
    public override string? DescribeActivationEffect => "breathe sound (130) every 450+d450 turns";
    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    public override string Name => "Gold Dragon Scale Mail";

    public override int ArmorClass => 30;
    public override bool Activate => true;
    public override int Cost => 40000;
    public override int DamageDice => 2;
    public override int DamageSides => 4;
    public override string FriendlyName => "Gold Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 65;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (65, 8)
    };
    public override bool ResSound => true;
    public override int BonusArmorClass => 10;
    public override int BonusHit => -2;
    public override int Weight => 200;

    /// <summary>
    /// Returns the on-body inventory slot for scale mail.
    /// </summary>
    public override int WieldSlot => InventorySlot.OnBody;

    /// <summary>
    /// Returns a treasure rating of 30 for dragon scale mail items.
    /// </summary>
    public override int TreasureRating => 30;
    protected override string ItemClassName => nameof(DragonScaleMailsItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(OnBodyInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.DragArmor;
    public override int PackSort => 19;
    public override bool HatesAcid => true;
}
