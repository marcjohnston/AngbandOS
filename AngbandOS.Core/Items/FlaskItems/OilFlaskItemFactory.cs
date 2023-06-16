namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class OilFlaskItemFactory : FlaskItemFactory
{
    private OilFlaskItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    /// <summary>
    /// Returns true because a flask of oil is valid as fuel for lanterns.
    /// </summary>
    public override bool IsFuelForLantern => true;
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Flask of oil";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 3;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "& Flask~ of oil";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int Pval => 7500;
    public override int? SubCategory => 0;
    public override int Weight => 10;
    public override Item CreateItem() => new OilFlaskItem(SaveGame);
}
