// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WoodenArrowAmmunitionItemFactory : ArrowAmmunitionItemFactory
{
    private WoodenArrowAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBracketSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Arrow";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 1;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "& Arrow~";
    public override int LevelNormallyFound => 3;
    public override int[] Locale => new int[] { 3, 15, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(SaveGame, this);
}
