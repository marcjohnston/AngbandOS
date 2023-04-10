namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CallOfTheWildNatureBookItem : NatureBookItem
    {
        public CallOfTheWildNatureBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<NatureBookCallOfTheWild>()) { }
    }
}