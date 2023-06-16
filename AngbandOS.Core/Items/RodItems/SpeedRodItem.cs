namespace AngbandOS.Core.Items;

[Serializable]
internal class SpeedRodItem : RodItem
{
    public SpeedRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodSpeed>()) { }
}