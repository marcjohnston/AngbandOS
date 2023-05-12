namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlackDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BlackDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlackDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe acid.");
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), dir, 130, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
            return;
        }
    }
}