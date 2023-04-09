namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FireBallsWandItem : WandItem
    {
        public FireBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandFireBalls>()) { }
        public override bool IgnoreFire => true;
    }
}