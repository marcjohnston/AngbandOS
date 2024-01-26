// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BladeOfChaosWeaponItemFactory : SwordWeaponItemFactory
{
    private BladeOfChaosWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Blade of Chaos";

    public override bool Chaotic => true;
    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 4000;
    public override int Dd => 6;
    public override int Ds => 5;
    public override string FriendlyName => "& Blade~ of Chaos";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override bool ResChaos => true;
    public override bool ShowMods => true;
    public override int Weight => 180;
    public override Item CreateItem() => new BladeOfChaosSwordWeaponItem(SaveGame);
}
