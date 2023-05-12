namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlueDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BlueDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlueDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.MsgPrint("You breathe lightning.");
            SaveGame.FireBall(new ElecProjectile(SaveGame), dir, 100, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
        }

    }
}