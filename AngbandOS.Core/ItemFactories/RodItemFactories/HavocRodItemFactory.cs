// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HavocRodItemFactory : RodItemFactory
{
    private HavocRodItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Havoc";
    protected override string? DescriptionSyntax => "& $Flavor$ Rod~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Rod~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Rod~ of $Name$";
    public override int Cost => 150000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 95;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (100, 16)
    };
    public override int Weight => 15;
    public override int RodRechargeTime => 250;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        Game.RunScript(nameof(CallChaosScript));
        zapRodEvent.Identified = true;
        zapRodEvent.Item.RodRechargeTimeRemaining = RodRechargeTime;
    }
}
