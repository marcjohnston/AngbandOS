// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Items;

[Serializable]
internal class PowerDragonScaleMailArmorItem : DragonScaleMailArmorItem, IItemActivatable
{
    public PowerDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PowerDragonScaleMailArmorItemFactory>()) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.MsgPrint("You breathe the elements.");
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<MissileProjectile>(), dir, 300, -3);
        RechargeTimeLeft = SaveGame.Rng.RandomLessThan(300) + 300;
    }
}