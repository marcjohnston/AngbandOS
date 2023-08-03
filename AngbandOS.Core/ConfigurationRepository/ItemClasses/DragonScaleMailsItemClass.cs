namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class DragonScaleMailsItemClass : ItemClass
{
    private DragonScaleMailsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Dragon Scale Mails";
}