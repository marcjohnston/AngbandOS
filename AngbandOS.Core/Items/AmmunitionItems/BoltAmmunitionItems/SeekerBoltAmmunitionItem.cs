namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SeekerBoltAmmunitionItem : BoltAmmunitionItem
    {
        public SeekerBoltAmmunitionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SeekerBoltAmmunitionItemFactory>()) { }
    }
}