namespace AngbandOS.Core.Items;

[Serializable]
internal class HealingRodItem : RodItem
{
    public HealingRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodHealing>()) { }
}