// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OfDeflectionShieldArmorItemFactory : ShieldArmorItemFactory
{
    private OfDeflectionShieldArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Shield of Deflection";

    public override int ArmorClass => 10;
    public override int Cost => 10000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override int LevelNormallyFound => 70;
    public override string FriendlyName => "& Shield~ of Deflection";
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (70, 8)
    };
    public override int BonusArmorClass => 10;
    public override int Weight => 100;
}
