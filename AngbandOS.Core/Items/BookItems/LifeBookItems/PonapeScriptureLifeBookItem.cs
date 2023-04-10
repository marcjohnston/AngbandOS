namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PonapeScriptureLifeBookItem : LifeBookItem
    {
        public PonapeScriptureLifeBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LifeBookPonapeScripture>()) { }
    }
}