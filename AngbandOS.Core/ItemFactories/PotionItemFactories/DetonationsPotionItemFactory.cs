// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DetonationsPotionItemFactory : PotionItemFactory
{
    private DetonationsPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Detonations";

    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 10000;
    public override int Dd => 25;
    public override int Ds => 25;
    public override string FriendlyName => "Detonations";
    public override int LevelNormallyFound => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Detonations does 50d20 damage, stuns you, and gives you a stupid amount of bleeding
        Game.MsgPrint("Massive explosions rupture your body!");
        Game.TakeHit(Game.DiceRoll(50, 20), "a potion of Detonation");
        Game.StunTimer.AddTimer(75);
        Game.BleedingTimer.AddTimer(5000);
        return true;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, Game.DiceRoll(25, 25), Game.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}