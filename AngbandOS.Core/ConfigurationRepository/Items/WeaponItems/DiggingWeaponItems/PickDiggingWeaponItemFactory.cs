// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PickDiggingWeaponItemFactory : DiggingWeaponItemFactory
{
    private PickDiggingWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(BackSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Pick";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 50;
    public override int Dd => 1;
    public override int Ds => 3;
    public override string FriendlyName => "& Pick~";
    public override int Level => 5;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Pval => 1;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 150;
    public override Item CreateItem() => new PickDiggingWeaponItem(SaveGame);
}