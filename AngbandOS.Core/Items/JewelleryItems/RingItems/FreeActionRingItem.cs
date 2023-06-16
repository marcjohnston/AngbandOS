namespace AngbandOS.Core.Items;

[Serializable]
internal class FreeActionRingItem : RingItem
{
    public FreeActionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<FreeActionRingItemFactory>()) { }
}