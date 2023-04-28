namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlackPrayersDeathBookItem : DeathBookItem
    {
        public BlackPrayersDeathBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlackPrayersDeathBookItemFactory>()) { }
    }
}