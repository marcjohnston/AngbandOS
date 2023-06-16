namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class WaterPotionItemFactory : PotionItemFactory
{
    private WaterPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton
    public override char Character => '!';
    public override string Name => "Water";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Water";
    public override int Pval => 200;
    public override int? SubCategory => (int)PotionType.Water;
    public override int Weight => 4;

    public override bool Quaff(SaveGame saveGame)
    {
        // Water has no effect
        saveGame.MsgPrint("You feel less thirsty.");
        return true;
    }

    /// <summary>
    /// Returns null because water potions are always clear flavour.
    /// </summary>
    public override IEnumerable<Flavour>? GetFlavourRepository()
    {
        Flavour = SaveGame.SingletonRepository.PotionFlavours.Get<ClearPotionFlavour>();
        return null;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new WaterPotionItem(SaveGame);
}
