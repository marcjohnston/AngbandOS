namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LawDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public LawDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LawDragonScaleMailArmorItemFactory>()) { }
        public override void DoActivate()
        {
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            int chance = Program.Rng.RandomLessThan(2);
            string element = chance == 1 ? "sound" : "shards";
            SaveGame.MsgPrint($"You breathe {element}.");
            SaveGame.FireBall(chance == 1 ? (Projectile)new SoundProjectile(SaveGame) : new ExplodeProjectile(SaveGame), dir, 230, -2);
            RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
        }
    }
}