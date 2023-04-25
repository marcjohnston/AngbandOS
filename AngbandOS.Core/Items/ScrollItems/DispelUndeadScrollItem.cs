namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DispelUndeadScrollItem : ScrollItem
    {
        public DispelUndeadScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollDispelUndead>()) { }
    }
}