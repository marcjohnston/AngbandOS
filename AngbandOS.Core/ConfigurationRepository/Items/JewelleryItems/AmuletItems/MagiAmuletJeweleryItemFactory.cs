// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MagiAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private MagiAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(DoubleQuoteSymbol));
    public override string Name => "the Magi";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.Rng.DieRoll(5) + item.GetBonusValue(5, level);
        item.BonusArmorClass = SaveGame.Rng.DieRoll(5) + item.GetBonusValue(5, level);
        if (SaveGame.Rng.DieRoll(3) == 1)
        {
            item.RandartItemCharacteristics.SlowDigest = true;
        }
        SaveGame.TreasureRating += 25;
    }

    public override int[] Chance => new int[] { 4, 3, 0, 0 };
    public override int Cost => 30000;
    public override bool FreeAct => true;
    public override string FriendlyName => "the Magi";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 80, 0, 0 };
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override int ToA => 3;
    public override int Weight => 3;

    public override bool KindIsGood => true;
    public override Item CreateItem() => new MagiAmuletJeweleryItem(SaveGame);
}
