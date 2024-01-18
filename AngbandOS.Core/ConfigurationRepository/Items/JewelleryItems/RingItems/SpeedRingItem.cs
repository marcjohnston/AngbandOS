// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class SpeedRingItem : RingItem
{
    public SpeedRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get(nameof(SpeedRingItemFactory))) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power == 0 && SaveGame.Rng.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        TypeSpecificValue = SaveGame.Rng.DieRoll(5) + GetBonusValue(5, level);
        while (SaveGame.Rng.RandomLessThan(100) < 50)
        {
            TypeSpecificValue++;
        }
        if (power < 0)
        {
            IdentBroken = true;
            IdentCursed = true;
            TypeSpecificValue = 0 - TypeSpecificValue;
        }
        else
        {
            SaveGame.TreasureRating += 25;
        }
    }
}