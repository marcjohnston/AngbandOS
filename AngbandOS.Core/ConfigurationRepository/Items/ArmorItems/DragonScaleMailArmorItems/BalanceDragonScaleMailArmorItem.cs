namespace AngbandOS.Core.Items;

[Serializable]
internal class BalanceDragonScaleMailArmorItem : DragonScaleMailArmorItem, IItemActivatable
{
    public BalanceDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get(nameof(BalanceDragonScaleMailArmorItemFactory))) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = SaveGame.Rng.RandomLessThan(4);
        string element = chance == 1 ? "chaos" : (chance == 2 ? "disenchantment" : (chance == 3 ? "sound" : "shards"));
        SaveGame.MsgPrint($"You breathe {element}.");
        SaveGame.FireBall(chance == 1 ? SaveGame.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)) : (chance == 2 ? SaveGame.SingletonRepository.Projectiles.Get(nameof(DisenchantProjectile)) : (chance == 3 ? (Projectile)SaveGame.SingletonRepository.Projectiles.Get(nameof(SoundProjectile)) : SaveGame.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)))), dir, 250, -2);
        RechargeTimeLeft = SaveGame.Rng.RandomLessThan(300) + 300;
    }
}