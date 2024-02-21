// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SmallSwordWeaponItemFactory : SwordWeaponItemFactory
{
    private SmallSwordWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Small Sword";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 48;
    public override int Dd => 1;
    public override int Ds => 6;
    public override string FriendlyName => "& Small Sword~";
    public override int LevelNormallyFound => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 75;
    public override Item CreateItem() => new Item(SaveGame, this);
}
