// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class ProtectionRingItem : RingItem
{
    public ProtectionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ProtectionRingItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        BonusArmorClass = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
        if (power < 0)
        {
            IdentBroken = true;
            IdentCursed = true;
            BonusArmorClass = 0 - BonusArmorClass;
        }
    }
}