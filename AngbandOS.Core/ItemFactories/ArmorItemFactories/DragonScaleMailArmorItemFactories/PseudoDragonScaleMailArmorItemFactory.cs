// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PseudoDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private PseudoDragonScaleMailArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string ActivationScriptName => nameof(BreatheLightOrDarknessScript);
    public override int ActivationRechargeTime => Game.RandomLessThan(300) + 300;
    public override string? DescribeActivationEffect => "breathe light/darkness (200) every 300+d300 turns";
    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.Pink;
    public override string Name => "Pseudo Dragon Scale Mail";

    public override int ArmorClass => 30;
    public override bool Activate => true;
    public override int Cost => 60000;
    public override int DamageDice => 2;
    public override int DamageSides => 4;
    public override string FriendlyName => "Pseudo Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 65;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (65, 16)
    };
    public override bool ResDark => true;
    public override bool ResLight => true;
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
