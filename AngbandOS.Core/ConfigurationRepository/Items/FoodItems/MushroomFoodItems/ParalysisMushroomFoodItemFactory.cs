// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ParalysisMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private ParalysisMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override string Name => "Paralysis";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Paralysis";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Pval => 500;
    public override int Weight => 1;

    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        if (!SaveGame.HasFreeAction)
        {
            if (SaveGame.TimedParalysis.AddTimer(SaveGame.Rng.RandomLessThan(10) + 10))
            {
                return true;
            }
        }
        return false;
    }
    public override Item CreateItem() => new ParalysisMushroomFoodItem(SaveGame);
}