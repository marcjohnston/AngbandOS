namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class PotionsItemClass : ItemClass
{
    private PotionsItemClass(Game game) : base(game) { }
    public override string Name => "Potion";
}