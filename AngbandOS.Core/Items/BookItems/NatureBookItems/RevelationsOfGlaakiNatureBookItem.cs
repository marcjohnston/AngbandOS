namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RevelationsOfGlaakiNatureBookItem : NatureBookItem
    {
        public RevelationsOfGlaakiNatureBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<NatureBookRevelationsOfGlaaki>()) { }
    }
}