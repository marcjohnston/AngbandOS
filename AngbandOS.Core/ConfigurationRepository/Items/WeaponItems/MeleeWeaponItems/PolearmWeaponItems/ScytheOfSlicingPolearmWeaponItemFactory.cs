// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScytheOfSlicingPolearmWeaponItemFactory : PolearmWeaponItemFactory
{
    private ScytheOfSlicingPolearmWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Scythe of Slicing";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 3500;
    public override int Dd => 8;
    public override int Ds => 4;
    public override string FriendlyName => "& Scythe~ of Slicing";
    public override int Level => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 250;
    public override Item CreateItem() => new ScytheOfSlicingPolearmWeaponItem(SaveGame);
}