// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SleepPotionItemFactory : PotionItemFactory
{
    private SleepPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Sleep";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Sleep";
    public override int InitialNutritionalValue => 100;
    public override int Weight => 4;

    public override bool Quaff()
    {
        // Sleep paralyses you
        if (!Game.HasFreeAction)
        {
            if (Game.ParalysisTimer.AddTimer(Game.RandomLessThan(4) + 4))
            {
                return true;
            }
        }
        return false;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, 0, Game.SingletonRepository.Get<Projectile>(nameof(OldSleepProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
