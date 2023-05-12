namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public ChaosDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChaosDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            int chance = Program.Rng.RandomLessThan(2);
            string element = chance == 1 ? "chaos" : "disenchantment";
            SaveGame.MsgPrint($"You breathe {element}.");
            SaveGame.FireBall(projectile: chance == 1 ? (Projectile)SaveGame.SingletonRepository.Projectiles.Get<ChaosProjectile>() : SaveGame.SingletonRepository.Projectiles.Get<DisenchantProjectile>(), dir: dir, dam: 220, rad: -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
        }
    }
}