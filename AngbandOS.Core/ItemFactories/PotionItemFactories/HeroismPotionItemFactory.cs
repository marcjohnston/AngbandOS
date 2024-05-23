// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HeroismPotionItemFactory : PotionItemFactory
{
    private HeroismPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Heroism";

    public override int Cost => 35;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Heroism";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;
        // Heroism removes fear, cures 10 health, and gives you timed heroism
        if (Game.FearTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.HeroismTimer.AddTimer(Game.DieRoll(25) + 25))
        {
            identified = true;
        }
        if (Game.RestoreHealth(10))
        {
            identified = true;
        }
        return identified;
    }
}
