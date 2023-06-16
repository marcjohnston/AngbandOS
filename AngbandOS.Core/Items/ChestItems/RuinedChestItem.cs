namespace AngbandOS.Core.Items;

[Serializable]
internal class RuinedChestItem : ChestItem
{
    public RuinedChestItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChestRuined>()) { }
}