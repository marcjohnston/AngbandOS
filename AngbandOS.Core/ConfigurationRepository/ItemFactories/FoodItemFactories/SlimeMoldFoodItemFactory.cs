// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlimeMoldFoodItemFactory : FoodItemFactory
{
    private SlimeMoldFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Slime Mold";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 2;
    public override string FriendlyName => "& Slime Mold~";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 3000;
    public override int Weight => 5;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        PotionItemFactory slimeMold = (PotionItemFactory)SaveGame.SingletonRepository.ItemFactories.Get(nameof(SlimeMoldJuicePotionItemFactory));
        slimeMold.Quaff();
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}