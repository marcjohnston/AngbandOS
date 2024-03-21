namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class DragonScaleMailsItemClass : ItemClass
{
    private DragonScaleMailsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Dragon Scale Mail";
}