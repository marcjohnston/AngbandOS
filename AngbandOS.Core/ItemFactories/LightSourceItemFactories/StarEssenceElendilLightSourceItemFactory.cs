// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StarEssenceElendilLightSourceItemFactory : LightSourceItemFactory
{
    private StarEssenceElendilLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(AsteriskSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Star Essence Elendil";

    public override int Cost => 25000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    protected override string? DescriptionSyntax  => "& Star Essence~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 30;
    public override int Weight => 5;
    public override bool ProvidesSunlight => true;
}
