// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StupidityMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private StupidityMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override string Name => "Stupidity";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Stupidity";
    public override int LevelNormallyFound => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 500;
    public override int Weight => 1;
    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.TakeHit(Game.DiceRoll(8, 8), "poisonous food.");
        Game.TryDecreasingAbilityScore(Ability.Intelligence);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}