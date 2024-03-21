namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class StaffsItemClass : ItemClass
{
    private StaffsItemClass(Game game) : base(game) { }
    public override string Name => "Staff";
}