// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class GemstoneLightSourceItemFactory : LightSourceItemFactory
{
    private GemstoneLightSourceItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Gemstone";

    public override int Cost => 60000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Gemstone~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int Level => 60;
    public override int? SubCategory => LightType.Thrain;
    public override int Weight => 5;

    public override bool ProvidesSunlight => true;

    public override Item CreateItem() => new GemstoneLightSourceItem(SaveGame);
}
