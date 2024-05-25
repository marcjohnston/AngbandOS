// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SoundResistanceRingItemFactory : RingItemFactory
{
    private SoundResistanceRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Sound Resistance";
    protected override string? DescriptionSyntax => "& $Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Ring~ of $Name$";
    public override int Cost => 3000;
    public override bool EasyKnow => true;
    public override int LevelNormallyFound => 26;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (26, 2)
    };
    public override bool ResSound => true;
    public override int Weight => 2;
}
