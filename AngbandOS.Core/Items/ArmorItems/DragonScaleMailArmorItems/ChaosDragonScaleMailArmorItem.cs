// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

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