// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PoisonPotionItemFactory : PotionItemFactory
{
    private PoisonPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Poison";

    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Poison";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int Weight => 4;

    public override bool Quaff()
    {
        // Poison simply poisons you
        if (!(Game.HasPoisonResistance || Game.PoisonResistanceTimer.Value != 0))
        {
            // Hagarg Ryonis can protect you against poison
            if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                Game.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (Game.PoisonTimer.AddTimer(Game.RandomLessThan(15) + 10))
            {
                return true;
            }
        }
        return false;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, 3, Game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
}
