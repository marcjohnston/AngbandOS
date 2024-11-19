// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PowerRingItemFactory : ItemFactory
{
    private PowerRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolBindingKey => nameof(EqualSignSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Power";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override void Bind()
    {
        base.Bind();
        Flavor = Game.SingletonRepository.Get<RingReadableFlavor>(nameof(PlainGoldRingReadableFlavor));
    }

    public override int Cost => 5000000;
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 110;
    public override int Weight => 2;
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns true, because rings are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    protected override string ItemClassBindingKey => nameof(RingsItemClass);

    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(RightHandInventorySlot), nameof(LeftHandInventorySlot) };
    public override int PackSort => 16;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
}
