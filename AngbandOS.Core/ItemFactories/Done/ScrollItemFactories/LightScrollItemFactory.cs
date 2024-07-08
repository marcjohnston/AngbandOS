// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LightScrollItemFactory : ItemFactory
{
    private LightScrollItemFactory(Game game) : base(game) { } // This object is a singleton

    /// <summary>
    /// Returns true, because scrolls are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Light";
    protected override string? DescriptionSyntax => "Scroll~ titled \"$Flavor$\" of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "Scroll~ titled \"$Flavor$\"";
    protected override string? FlavorSuppressedDescriptionSyntax => "Scroll~ of $Name$";
    public override int Cost => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1),
        (3, 1),
        (10, 1)
    };
    public override int Weight => 5;

    protected override (string, int)? ActivateScrollScriptName => (nameof(Light2D8R2IdentifableAndUsedScript), 10);
    protected override string ItemClassName => nameof(ScrollsItemClass);

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (60, "3d5-3"),
        (240, "1d5-1")
    };

    protected override string BreakageChanceProbabilityExpression => "50/100";

    public override bool EasyKnow => true;
    public override int PackSort => 12;
    public override int BaseValue => 20;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBeige;
}
