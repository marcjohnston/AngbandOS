// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlownessPotionItemFactory : PotionItemFactory
{
    private SlownessPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Slowness";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Slowness";
    public override int LevelNormallyFound => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 50;
    public override int Weight => 4;

    public override bool Quaff()
    {
        // Slowness slows you down.
        return Game.SlowTimer.AddTimer(Game.DieRoll(25) + 15);
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, 5, Game.SingletonRepository.Projectiles.Get(nameof(OldSlowProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}