namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NatureMasteryNatureBookItem : NatureBookItem
    {
        public NatureMasteryNatureBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<NatureBookNatureMastery>()) { }
    }
}