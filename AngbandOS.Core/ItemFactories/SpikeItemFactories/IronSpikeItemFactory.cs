// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class IronSpikeItemFactory : SpikeItemFactory
{
    private IronSpikeItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(TildeSymbol));
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Iron Spike";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Iron Spike~";
    public override int LevelNormallyFound => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int Weight => 10;
    public override Item CreateItem() => new Item(Game, this);
}