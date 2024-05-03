// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SoftStuddedLeatherSoftArmorItemFactory : SoftArmorItemFactory
{
    private SoftStuddedLeatherSoftArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenParenthesisSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Soft Studded Leather";

    public override int ArmorClass => 5;
    public override int Cost => 35;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Soft Studded Leather~";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int Weight => 90;
}
