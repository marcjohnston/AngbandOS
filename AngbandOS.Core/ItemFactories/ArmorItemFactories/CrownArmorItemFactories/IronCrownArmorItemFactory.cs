// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class IronCrownArmorItemFactory : CrownArmorItemFactory
{
    private IronCrownArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Iron Crown";

    public override int Cost => 500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "& Iron Crown~";
    public override int LevelNormallyFound => 45;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (45, 1)
    };
    public override int Weight => 20;
}
