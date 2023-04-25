namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CurseArmorScrollItem : ScrollItem
    {
        public CurseArmorScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollCurseArmor>()) { }
    }
}