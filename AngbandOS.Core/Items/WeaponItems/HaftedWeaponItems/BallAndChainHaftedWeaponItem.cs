namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BallAndChainHaftedWeaponItem : HaftedWeaponItem
    {
        public BallAndChainHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HaftedBallAndChain>()) { }
    }
}