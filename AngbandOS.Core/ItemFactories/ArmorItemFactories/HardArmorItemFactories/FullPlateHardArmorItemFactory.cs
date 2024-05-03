// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FullPlateHardArmorItemFactory : HardArmorItemFactory
{
    private FullPlateHardArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Full Plate Armor";

    public override int ArmorClass => 25;
    public override int Cost => 1350;
    public override int DamageDice => 2;
    public override int DamageSides => 4;
    public override string FriendlyName => "Full Plate Armor~";
    public override int LevelNormallyFound => 45;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (45, 1)
    };
    public override int BonusHit => -3;
    public override int Weight => 380;
}
