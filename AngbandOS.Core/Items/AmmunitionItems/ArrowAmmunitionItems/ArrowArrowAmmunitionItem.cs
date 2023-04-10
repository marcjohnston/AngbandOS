namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ArrowArrowAmmunitionItem : ArrowAmmunitionItem
    {
        public ArrowArrowAmmunitionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ArrowArrowAmmunitionFactory>()) { }
    }
}