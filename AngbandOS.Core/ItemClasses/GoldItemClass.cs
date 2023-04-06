namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class GoldItemClass : ItemClass
    {
        public GoldItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gold;
        //public override bool IgnoredByMonsters => true;
        public override int? SubCategory => null; // No longer used by gold.
        public static bool IsGold(ItemClass itemClass)
        {
            return typeof(GoldItemClass).IsAssignableFrom(itemClass.GetType());
        }
    }
}
