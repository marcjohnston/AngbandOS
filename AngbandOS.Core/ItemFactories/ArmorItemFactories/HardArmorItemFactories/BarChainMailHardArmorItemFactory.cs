// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BarChainMailHardArmorItemFactory : HardArmorItemFactory
{
    private BarChainMailHardArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Bar Chain Mail";

    public override int Ac => 18;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 950;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "Bar Chain Mail~";
    public override int LevelNormallyFound => 35;
    public override int[] Locale => new int[] { 35, 0, 0, 0 };
    public override int ToH => -2;
    public override int Weight => 280;
    public override Item CreateItem() => new Item(Game, this);
}