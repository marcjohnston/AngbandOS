// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ExecutionersSwordWeaponItemFactory : SwordWeaponItemFactory
{
    private ExecutionersSwordWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Executioner's Sword";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 850;
    public override int Dd => 4;
    public override int Ds => 5;
    public override string FriendlyName => "& Executioner's Sword~";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 260;
    public override Item CreateItem() => new ExecutionersSwordWeaponItem(SaveGame);
}