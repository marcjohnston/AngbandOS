namespace AngbandOS.Core.Items;

[Serializable]
internal class HavocRodItem : RodItem
{
    public HavocRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodHavoc>()) { }
}