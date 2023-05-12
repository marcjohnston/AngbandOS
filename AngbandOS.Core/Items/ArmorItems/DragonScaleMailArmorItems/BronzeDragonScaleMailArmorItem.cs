namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BronzeDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BronzeDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BronzeDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe confusion.");
            SaveGame.FireBall(new ConfusionProjectile(SaveGame), dir, 120, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
        }
    }
}