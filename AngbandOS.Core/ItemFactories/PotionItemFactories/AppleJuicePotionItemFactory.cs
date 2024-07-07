// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AppleJuicePotionItemFactory : PotionItemFactory
{
    private AppleJuicePotionItemFactory(Game game) : base(game) { } // This object is a singleton
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Apple Juice";
    protected override string? DescriptionSyntax => "$Flavor$ Potion~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Potion~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Potion~ of $Name$";
    public override void Bind()
    {
        base.Bind();
        Flavor = Game.SingletonRepository.Get<PotionReadableFlavor>(nameof(LightBrownPotionReadableFlavor));
    }
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int Cost => 1;
    public override int DamageDice => 1;
    public override int DamageSides => 1;

    /// <summary>
    /// Returns 250 turns of sustenance for this apply juice food item.
    /// </summary>
    public override int InitialNutritionalValue => 250;

    public override int Weight => 4;
    protected override (string, string?, int)? QuaffNoticeableScriptName => (nameof(AppleJuiceScript), nameof(NoEffectButMakeUnfriendlyScript), 20);
}
