// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ConstitutionRingItemFactory : RingItemFactory
{
    private ConstitutionRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Constitution";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power == 0 && SaveGame.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        item.TypeSpecificValue = 1 + item.GetBonusValue(5, level);
        if (power < 0)
        {
            item.IdentBroken = true;
            item.IdentCursed = true;
            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        }
    }

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override bool Con => true;
    public override int Cost => 500;
    public override string FriendlyName => "Constitution";
    public override bool HideType => true;
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int Weight => 2;
    public override Item CreateItem() => new Item(SaveGame, this);
}
