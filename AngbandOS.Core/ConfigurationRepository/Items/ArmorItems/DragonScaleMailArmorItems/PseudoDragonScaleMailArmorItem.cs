// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Items;

[Serializable]
internal class PseudoDragonScaleMailArmorItem : DragonScaleMailArmorItem, IItemActivatable
{
    public PseudoDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PseudoDragonScaleMailArmorItemFactory>()) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = SaveGame.Rng.RandomLessThan(2);
        string element = chance == 0 ? "light" : "darkness";
        SaveGame.MsgPrint($"You breathe {element}.");
        SaveGame.FireBall(chance == 0 ? (Projectile)SaveGame.SingletonRepository.Projectiles.Get<LightProjectile>() : SaveGame.SingletonRepository.Projectiles.Get<DarkProjectile>(), dir, 200, -2);
        RechargeTimeLeft = SaveGame.Rng.RandomLessThan(300) + 300;
    }
}