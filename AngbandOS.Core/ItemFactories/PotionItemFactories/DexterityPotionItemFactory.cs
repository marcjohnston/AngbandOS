// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DexterityPotionItemFactory : PotionItemFactory
{
    private DexterityPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Dexterity";

    public override int Cost => 8000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Dexterity";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 6),
        (25, 3),
        (30, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Dexterity increases your dexterity
        return Game.TryIncreasingAbilityScore(Ability.Dexterity);
    }
    public override Item CreateItem() => new Item(Game, this);
}
