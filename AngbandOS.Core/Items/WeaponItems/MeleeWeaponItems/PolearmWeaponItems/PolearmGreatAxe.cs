// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PolearmGreatAxe : PolearmItemClass
{
    private PolearmGreatAxe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Great Axe";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 500;
    public override int Dd => 4;
    public override int Ds => 4;
    public override string FriendlyName => "& Great Axe~";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int? SubCategory => 25;
    public override int Weight => 230;
    public override Item CreateItem() => new GreatAxePolearmWeaponItem(SaveGame);
}
