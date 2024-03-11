// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CurePoisonMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private CurePoisonMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override string Name => "Cure Poison";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 60;
    public override string FriendlyName => "Cure Poison";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 500;
    public override int Weight => 1;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        if (SaveGame.PoisonTimer.ResetTimer())
        {
            return true;
        }
        return false;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
