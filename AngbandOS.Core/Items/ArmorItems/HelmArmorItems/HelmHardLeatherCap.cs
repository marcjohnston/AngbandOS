// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HelmHardLeatherCap : HelmItemClass
{
    private HelmHardLeatherCap(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hard Leather Cap";

    public override int Ac => 2;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 12;
    public override string FriendlyName => "& Hard Leather Cap~";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 15;
    public override Item CreateItem() => new HardLeatherCapHelmArmorItem(SaveGame);
}
