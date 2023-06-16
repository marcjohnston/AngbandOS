namespace AngbandOS.Core.Items;

[Serializable]
internal class AdamantitePlateMailHardArmorItem : HardArmorItem
{
    public AdamantitePlateMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorAdamantitePlateMail>()) { }
}