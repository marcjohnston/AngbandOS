namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BasicChiFlowCorporealBookItem : CorporealBookItem
    {
        public BasicChiFlowCorporealBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CorporealBookBasicChiFlow>()) { }
    }
}