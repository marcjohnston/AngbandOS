// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RobeSoftArmorItemFactory : SoftArmorItemFactory
{
    private RobeSoftArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(OpenParenthesisSymbol));
    public override ColorEnum Color => ColorEnum.Blue;
    public override string Name => "Robe";


    /// <summary>
    /// Applies special magic to this robe.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(item, level, power, null);

            if (power > 1)
            {
                // Robes have a chance of having the armor of permanence instead of a random characteristic.
                if (Game.RandomLessThan(100) < 10)
                {
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(ArmorOfPermanenceRareItem));
                }
                else
                {
                    ApplyRandomGoodRareCharacteristics(item);
                }
            }
        }
    }

    public override int Ac => 2;
    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 4;
    public override string FriendlyName => "& Robe~";
    public override int LevelNormallyFound => 1;
    public override int[] Locale => new int[] { 1, 50, 0, 0 };
    public override int Weight => 20;
    public override Item CreateItem() => new Item(Game, this);
}
