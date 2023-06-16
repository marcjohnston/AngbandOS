// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class SearchingAmuletJeweleryItem : AmuletJeweleryItem
{
    public SearchingAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SearchingAmuletJeweleryItemFactory>()) { }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
        if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
        {
            IdentBroken = true;
            IdentCursed = true;
            TypeSpecificValue = 0 - TypeSpecificValue;
        }
    }
}