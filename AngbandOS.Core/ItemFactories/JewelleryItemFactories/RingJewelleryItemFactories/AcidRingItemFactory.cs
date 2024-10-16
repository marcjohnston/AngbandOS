// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AcidRingItemFactory : RingItemFactory
{
    private AcidRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string? ActivationName => nameof(BallOfAcid50r2AndResistAcid1d20p20ctivation);
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (null, null, new string[] { nameof(BonusArmorClass1D5P10BP5EnchantmentScript) })
    };
    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Acid";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";
    public override int Cost => 2000;
    public override bool IgnoreAcid => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override bool ResAcid => true;
    public override int BonusArmorClass => 15;
    public override int Weight => 2;
}
