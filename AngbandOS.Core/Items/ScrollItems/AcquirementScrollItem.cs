namespace AngbandOS.Core.Items;

[Serializable]
internal class AcquirementScrollItem : ScrollItem
{
    public AcquirementScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollAcquirement>()) { }
}