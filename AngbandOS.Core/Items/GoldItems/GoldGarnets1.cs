// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GoldGarnets1 : GoldItemClass
{
    private GoldGarnets1(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '$';
    public override Colour Colour => Colour.Red;
    public override string Name => "garnets*";

    public override int Cost => 10;
    public override string FriendlyName => "garnets";
    public override int Level => 1;
    public override Item CreateItem() => new Garnets1GoldItem(SaveGame);
}
