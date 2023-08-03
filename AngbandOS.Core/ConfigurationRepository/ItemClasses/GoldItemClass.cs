namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class GoldItemClass : ItemClass
{
    private GoldItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Gold";
    public override bool AllowStomp => false;
}