namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WhiteDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public WhiteDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WhiteDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe frost.");
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 110, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
        }
    }
}