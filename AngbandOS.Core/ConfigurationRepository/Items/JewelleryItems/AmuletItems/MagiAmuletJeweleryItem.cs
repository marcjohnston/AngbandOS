// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class MagiAmuletJeweleryItem : AmuletJeweleryItem
{
    public MagiAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get(nameof(MagiAmuletJeweleryItemFactory))) { }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = SaveGame.Rng.DieRoll(5) + GetBonusValue(5, level);
        BonusArmorClass = SaveGame.Rng.DieRoll(5) + GetBonusValue(5, level);
        if (SaveGame.Rng.DieRoll(3) == 1)
        {
            RandartItemCharacteristics.SlowDigest = true;
        }
        SaveGame.TreasureRating += 25;
    }
}