namespace AngbandOS.Core.Items;

[Serializable]
internal class LightningBallsRodItem : RodItem
{
    public LightningBallsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodLightningBalls>()) { }
}