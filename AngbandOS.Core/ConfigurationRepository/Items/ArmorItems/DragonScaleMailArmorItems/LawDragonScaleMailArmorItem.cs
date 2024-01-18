// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class LawDragonScaleMailArmorItem : DragonScaleMailArmorItem, IItemActivatable
{
    public LawDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get(nameof(LawDragonScaleMailArmorItemFactory))) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = SaveGame.Rng.RandomLessThan(2);
        string element = chance == 1 ? "sound" : "shards";
        SaveGame.MsgPrint($"You breathe {element}.");
        SaveGame.FireBall(chance == 1 ? (Projectile)SaveGame.SingletonRepository.Projectiles.Get(nameof(SoundProjectile)) : SaveGame.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)), dir, 230, -2);
        RechargeTimeLeft = SaveGame.Rng.RandomLessThan(300) + 300;
    }
}