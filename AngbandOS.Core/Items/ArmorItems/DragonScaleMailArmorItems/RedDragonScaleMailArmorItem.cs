namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RedDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public RedDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RedDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe fire.");
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, 200, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
        }
    }
}