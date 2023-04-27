namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfGauntletsGlovesArmourItem : GlovesArmourItem
    {
        public SetOfGauntletsGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GlovesSetOfGauntlets>()) { }
    }
}