namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SeekerArrowAmmunitionItem : ArrowAmmunitionItem
    {
        public SeekerArrowAmmunitionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SeekerArrowAmmunitionFactory>()) { }
    }
}