namespace AngbandOS.Core.Items
{
[Serializable]
    internal class Silver2GoldItem : GoldItem
    {
        public Silver2GoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldSilver2>()) { }
    }
}