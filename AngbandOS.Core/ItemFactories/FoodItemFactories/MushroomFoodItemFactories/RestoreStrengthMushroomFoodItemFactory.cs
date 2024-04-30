// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RestoreStrengthMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private RestoreStrengthMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(CommaSymbol));
    public override string Name => "Restore Strength";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 350;
    public override string FriendlyName => "Restore Strength";
    public override int LevelNormallyFound => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 1;
    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (Game.TryRestoringAbilityScore(Ability.Strength))
        {
            return true;
        }
        return false;
    }
    public override Item CreateItem() => new Item(Game, this);
}
