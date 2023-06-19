// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class MultiHuedDragonScaleMailArmorItem : DragonScaleMailArmorItem, IItemActivatable
{
    public MultiHuedDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MultiHuedDragonScaleMailArmorItemFactory>()) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = Program.Rng.RandomLessThan(5);
        string element = chance == 1 ? "lightning" : (chance == 2 ? "frost" : (chance == 3 ? "acid" : (chance == 4 ? "poison gas" : "fire")));
        SaveGame.MsgPrint($"You breathe {element}.");
        switch (chance)
        {
            case 0:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, 250, -2);
                return;
            case 1:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), dir, 250, -2);
                return;

            case 2:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 250, -2);
                return;

            case 3:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), dir, 250, -2);
                return;

            case 4:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), dir, 250, -2);
                return;
        }
        RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
    }
}