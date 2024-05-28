// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RuneOfProtectionScrollItemFactory : ScrollItemFactory
{
    private RuneOfProtectionScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Rune of Protection";
    protected override string? DescriptionSyntax => "Scroll~ titled \"$Flavor$\" of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "Scroll~ titled \"$Flavor$\"";
    protected override string? FlavorSuppressedDescriptionSyntax => "Scroll~ of $Name$";
    public override int Cost => 500;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 2),
        (90, 4)
    };
    public override int Weight => 5;

    protected override string? ActivateScrollScriptName => nameof(RuneOfProtectionIdentifableAndUsedScript);
}
