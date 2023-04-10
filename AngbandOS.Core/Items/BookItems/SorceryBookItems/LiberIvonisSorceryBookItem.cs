namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LiberIvonisSorceryBookItem : SorceryBookItem
    {
        public LiberIvonisSorceryBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SorceryBookLiberIvonis>()) { }
    }
}