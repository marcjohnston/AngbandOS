// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class BronzeDragonScaleMailArmorItem : DragonScaleMailArmorItem, IItemActivatable
{
    public BronzeDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get(nameof(BronzeDragonScaleMailArmorItemFactory))) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.MsgPrint("You breathe confusion.");
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ConfusionProjectile)), dir, 120, -2);
        RechargeTimeLeft = SaveGame.Rng.RandomLessThan(450) + 450;
    }
}