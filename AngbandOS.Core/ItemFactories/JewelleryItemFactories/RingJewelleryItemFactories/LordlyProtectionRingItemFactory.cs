// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LordlyProtectionRingItemFactory : RingItemFactory
{
    private LordlyProtectionRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Lordly Protection";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    /// <summary>
    /// Returns the base ring treasure rating plus 5 for rings of lordly protection.
    /// </summary>
    public override int TreasureRating => base.TreasureRating + 5;

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        do
        {
            item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(LordlyResistanceItemAdditiveBundleWeightedRandom)));
        } while (Game.DieRoll(4) == 1);
        item.BonusArmorClass = 10 + Game.DieRoll(5) + item.GetBonusValue(10, level);
    }
    public override int Cost => 100000;
    public override bool FreeAct => true;
    public override bool HoldLife => true;
    public override int LevelNormallyFound => 100;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (100, 5)
    };
    public override bool ResDisen => true;
    public override bool ResPois => true;
    public override int Weight => 2;
}
