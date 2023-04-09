namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OfDeflectionShieldArmorItem : ShieldArmorItem
    {
        public OfDeflectionShieldArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ShieldShieldOfDeflection>()) { }
    }
}