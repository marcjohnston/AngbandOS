namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class GoldItemClass : ItemFactory
{
    public GoldItemClass(SaveGame saveGame) : base(saveGame) { }
    public override int PackSort => 0;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gold;
    //public override bool IgnoredByMonsters => true;
    public override int? SubCategory => null; // No longer used by gold.
}
