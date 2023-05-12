namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GoldDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public GoldDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe sound.");
            SaveGame.FireBall(new SoundProjectile(SaveGame), dir, 130, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
        }
    }
}