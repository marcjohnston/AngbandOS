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

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(ExclamationPointSymbol));
    public override string Name => "Poison";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Poison";
    public override int LevelNormallyFound => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
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
        Game.Project(who, 2, y, x, 3, Game.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
