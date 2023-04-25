namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LeatherScaleMailSoftArmorItem : SoftArmorItem
    {
        public LeatherScaleMailSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SoftArmorLeatherScaleMail>()) { }
    }
}