// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StripOfVenisonFoodItemFactory : FoodItemFactory
{
    private StripOfVenisonFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Strip of Venison";

    public override int Cost => 2;
    public override string FriendlyName => "& Strip~ of Venison";
    public override int InitialTypeSpecificValue => 1500;
    public override int Weight => 2;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        SaveGame.MsgPrint("That tastes good.");
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}