// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class IceRingItem : RingItem, IItemActivatable
{
    public IceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<IceRingItemFactory>()) { }
    public void DoActivate()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 50, 2);
        SaveGame.Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
    }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        BonusArmorClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
    }
}