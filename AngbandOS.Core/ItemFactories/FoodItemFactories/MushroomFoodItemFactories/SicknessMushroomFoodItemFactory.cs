// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SicknessMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private SicknessMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override string Name => "Sickness";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 4;
    public override int Ds => 4;
    public override string FriendlyName => "Sickness";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 500;
    public override int Weight => 1;

    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.TakeHit(Game.DiceRoll(6, 6), "poisonous food.");
        Game.TryDecreasingAbilityScore(Ability.Constitution);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}