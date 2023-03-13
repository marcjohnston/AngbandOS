namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AdamantitePlateMailHardArmorItem : HardArmorItem
    {
        public AdamantitePlateMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HardArmorAdamantitePlateMail>()) { }
    }
}