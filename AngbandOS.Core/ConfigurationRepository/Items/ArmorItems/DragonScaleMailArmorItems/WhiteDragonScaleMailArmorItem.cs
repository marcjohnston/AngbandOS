// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Items;

[Serializable]
internal class WhiteDragonScaleMailArmorItem : DragonScaleMailArmorItem, IItemActivatable
{
    public WhiteDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WhiteDragonScaleMailArmorItemFactory>()) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.MsgPrint("You breathe frost.");
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 110, -2);
        RechargeTimeLeft = SaveGame.Rng.RandomLessThan(450) + 450;
    }
}