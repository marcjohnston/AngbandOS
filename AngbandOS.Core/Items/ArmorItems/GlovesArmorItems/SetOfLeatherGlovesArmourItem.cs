namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SetOfLeatherGlovesArmourItem : GlovesArmourItem
    {
        public SetOfLeatherGlovesArmourItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GlovesSetOfLeatherGloves>()) { }
    }
}