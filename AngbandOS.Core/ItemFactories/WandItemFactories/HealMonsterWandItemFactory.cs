// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HealMonsterWandItemFactory : WandItemFactory
{
    private HealMonsterWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Heal Monster";
    protected override string? DescriptionSyntax => "$Flavor$ Wand~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Wand~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Wand~ of $Name$";
    public override int RodChargeCount => Game.DieRoll(20) + 8;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 2;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (2, 1)
    };
    public override int Weight => 10;
    public override bool ActivateWand(int dir)
    {
        return Game.HealMonster(dir);
    }
}
