namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GreenDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public GreenDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GreenDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe poison gas.");
            SaveGame.FireBall(new PoisProjectile(SaveGame), dir, 150, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
        }
    }
}