namespace AngbandOS.Core.Items
{
[Serializable]
    internal class UnaussprechlichenKultenSorceryBookItem : SorceryBookItem
    {
        public UnaussprechlichenKultenSorceryBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SorceryBookUnaussprechlichenKulten>()) { }
    }
}