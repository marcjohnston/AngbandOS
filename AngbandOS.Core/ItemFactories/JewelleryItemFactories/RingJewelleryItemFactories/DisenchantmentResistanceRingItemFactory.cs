// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DisenchantmentResistanceRingItemFactory : RingItemFactory
{
    private DisenchantmentResistanceRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(EqualSignSymbol));
    public override string Name => "Disenchantment Resistance";

    public override int[] Chance => new int[] { 10, 0, 0, 0 };
    public override int Cost => 15000;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Disenchantment Resistance";
    public override int LevelNormallyFound => 90;
    public override int[] Locale => new int[] { 90, 0, 0, 0 };
    public override bool ResDisen => true;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}
