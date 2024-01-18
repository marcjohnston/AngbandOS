// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class AccuracyRingItem : RingItem
{
    public AccuracyRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get(nameof(AccuracyRingItemFactory))) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power == 0 && SaveGame.Rng.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        BonusToHit = 5 + SaveGame.Rng.DieRoll(8) + GetBonusValue(10, level);
        if (power < 0)
        {
            IdentBroken = true;
            IdentCursed = true;
            BonusToHit = 0 - BonusToHit;
        }
    }
}