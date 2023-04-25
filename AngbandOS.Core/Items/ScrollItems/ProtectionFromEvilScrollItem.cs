namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ProtectionFromEvilScrollItem : ScrollItem
    {
        public ProtectionFromEvilScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollProtectionFromEvil>()) { }
    }
}