namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MagicMappingScrollItem : ScrollItem
    {
        public MagicMappingScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollMagicMapping>()) { }
    }
}