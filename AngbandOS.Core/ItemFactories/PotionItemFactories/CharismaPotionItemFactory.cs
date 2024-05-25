// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CharismaPotionItemFactory : PotionItemFactory
{
    private CharismaPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Charisma";
    protected override string? DescriptionSyntax => "& $Flavor$ Potion~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Potion~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Potion~ of $Name$";
    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1),
        (25, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Charisma increases your charisma
        return Game.TryIncreasingAbilityScore(Ability.Charisma);
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
}
