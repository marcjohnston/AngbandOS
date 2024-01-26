// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScythePolearmWeaponItemFactory : PolearmWeaponItemFactory
{
    private ScythePolearmWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Scythe";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 800;
    public override int Dd => 5;
    public override int Ds => 3;
    public override string FriendlyName => "& Scythe~";
    public override int Level => 45;
    public override int[] Locale => new int[] { 45, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 250;
    public override Item CreateItem() => new ScythePolearmWeaponItem(SaveGame);
}
