// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SoftLeatherBootsArmorItemFactory : BootsArmorItemFactory
{
    private SoftLeatherBootsArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Pair of Soft Leather Boots";

    public override int Ac => 2;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 7;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Pair~ of Soft Leather Boots";
    public override int LevelNormallyFound => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 20;
    public override Item CreateItem() => new Item(Game, this);
}