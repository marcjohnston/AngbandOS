namespace AngbandOS.Core.Items;

[Serializable]
internal class SmallIronChestItem : ChestItem
{
    public SmallIronChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChestSmallIron>()) { }
}