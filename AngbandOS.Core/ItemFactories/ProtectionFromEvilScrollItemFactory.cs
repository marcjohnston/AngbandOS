// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ProtectionFromEvilScrollItemFactory : ItemFactory
{
    private ProtectionFromEvilScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Protection from Evil";
    protected override string? DescriptionSyntax => "Scroll~ titled \"$Flavor$\" of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "Scroll~ titled \"$Flavor$\"";
    protected override string? FlavorSuppressedDescriptionSyntax => "Scroll~ of $Name$";
    public override int Cost => 250;
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 1)
    };
    public override int Weight => 5;

    protected override string? ActivateScrollScriptName => nameof(ProtectionFromEvilIdentifableAndUsedScript);
    protected override string ItemClassName => nameof(ScrollsItemClass);

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (60, "3d5-3"),
        (240, "1d5-1")
    };

    public override int PercentageBreakageChance => 50;

    public override bool EasyKnow => true;
    public override int PackSort => 12;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Scroll;
    public override int BaseValue => 20;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBeige;
}
