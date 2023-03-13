namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LeadCrownArmorItem : CrownArmorItem
    {
        public LeadCrownArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CrownLead>()) { }
    }
}