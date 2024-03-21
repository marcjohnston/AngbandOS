namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class GoldItemClass : ItemClass
{
    private GoldItemClass(Game game) : base(game) { }
    public override string Name => "Gold";
    public override bool AllowStomp => false;
}