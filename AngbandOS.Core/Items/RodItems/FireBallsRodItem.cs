namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FireBallsRodItem : RodItem
    {
        public FireBallsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodFireBalls>()) { }
    }
}