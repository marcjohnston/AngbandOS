namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PseudoDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public PseudoDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PseudoDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            int chance = Program.Rng.RandomLessThan(2);
            string element = chance == 0 ? "light" : "darkness";
            SaveGame.MsgPrint($"You breathe {element}.");
            SaveGame.FireBall(chance == 0 ? (Projectile)new LightProjectile(SaveGame) : new DarkProjectile(SaveGame), dir, 200, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
        }
    }
}