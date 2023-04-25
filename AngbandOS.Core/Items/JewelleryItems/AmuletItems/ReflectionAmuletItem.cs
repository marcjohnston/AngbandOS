namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ReflectionAmuletItem : AmuletItem
    {
        public ReflectionAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletReflection>()) { }
    }
}