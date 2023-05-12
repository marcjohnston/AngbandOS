namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PowerDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public PowerDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PowerDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe the elements.");
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<MissileProjectile>(), dir, 300, -3);
            RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
        }
    }
}