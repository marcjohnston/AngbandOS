namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CthaatAquadingenNatureBookItem : NatureBookItem
    {
        public CthaatAquadingenNatureBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<NatureBookCthaatAquadingen>()) { }
    }
}