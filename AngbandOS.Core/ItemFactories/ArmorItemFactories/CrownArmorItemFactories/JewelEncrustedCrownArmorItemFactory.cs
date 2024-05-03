// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class JewelEncrustedCrownArmorItemFactory : CrownArmorItemFactory
{
    private JewelEncrustedCrownArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Jewel Encrusted Crown";

    public override int Cost => 2000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "& Jewel Encrusted Crown~";
    public override bool IgnoreAcid => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1)
    };
    public override int Weight => 40;
}
