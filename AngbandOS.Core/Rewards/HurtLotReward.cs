namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class HurtLotReward : Reward
    {
        private HurtLotReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            string wrathReason = $"the Wrath of {patron.ShortName}";
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Suffer, pathetic fool!'");
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<DisintegrateProjectile>(), 0, SaveGame.Player.Level * 4, 4);
            SaveGame.Player.TakeHit(SaveGame.Player.Level * 4, wrathReason);
        }
    }
}