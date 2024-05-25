// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AugmentationPotionItemFactory : PotionItemFactory
{
    private AugmentationPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Augmentation";
    protected override string? DescriptionSyntax => "& $Flavor$ Potion~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Potion~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Potion~ of $Name$";
    public override int Cost => 60000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 16)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        return Game.RunNoticeableScript(nameof(AugmentScript));
    }
}
