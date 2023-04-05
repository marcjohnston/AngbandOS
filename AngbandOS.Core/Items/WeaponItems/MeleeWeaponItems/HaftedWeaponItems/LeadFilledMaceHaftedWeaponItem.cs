namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LeadFilledMaceHaftedWeaponItem : HaftedWeaponItem
    {
        public LeadFilledMaceHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HaftedLeadFilledMace>()) { }
    }
}