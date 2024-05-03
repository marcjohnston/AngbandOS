// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ParalysisMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private ParalysisMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override string Name => "Paralysis";

    public override string FriendlyName => "Paralysis";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 1;

    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (!Game.HasFreeAction)
        {
            if (Game.ParalysisTimer.AddTimer(Game.RandomLessThan(10) + 10))
            {
                return true;
            }
        }
        return false;
    }
    public override Item CreateItem() => new Item(Game, this);
}
