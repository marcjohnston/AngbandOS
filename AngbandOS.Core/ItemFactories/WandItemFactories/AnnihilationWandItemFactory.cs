// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AnnihilationWandItemFactory : WandItemFactory
{
    private AnnihilationWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override int RodChargeCount => Game.DieRoll(2) + 1;
    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Annihilation";

    public override int Cost => 3000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Annihilation";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 60;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (60, 4)
    };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        return game.DrainLife(dir, 125);
    }
}
