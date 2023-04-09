namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PnakoticManuscriptsCorporealBookItem : CorporealBookItem
    {
        public PnakoticManuscriptsCorporealBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CorporealBookPnakoticManuscripts>()) { }
    }
}