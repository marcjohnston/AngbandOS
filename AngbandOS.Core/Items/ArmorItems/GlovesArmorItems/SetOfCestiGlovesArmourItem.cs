namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfCestiGlovesArmourItem : GlovesArmourItem
    {
        public SetOfCestiGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GlovesSetOfCesti>()) { }
    }
}