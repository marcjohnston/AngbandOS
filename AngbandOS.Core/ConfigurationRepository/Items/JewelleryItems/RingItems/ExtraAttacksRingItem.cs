// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Items;

[Serializable]
internal class ExtraAttacksRingItem : RingItem
{
    public ExtraAttacksRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ExtraAttacksRingItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power == 0 && SaveGame.Rng.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        TypeSpecificValue = GetBonusValue(3, level);
        if (TypeSpecificValue < 1)
        {
            TypeSpecificValue = 1;
        }
        if (power < 0)
        {
            IdentBroken = true;
            IdentCursed = true;
            TypeSpecificValue = 0 - TypeSpecificValue;
        }
    }
}