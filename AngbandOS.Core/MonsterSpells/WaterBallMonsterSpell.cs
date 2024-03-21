// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class WaterBallMonsterSpell : BallProjectileMonsterSpell
{
    private WaterBallMonsterSpell(Game game) : base(game) { }
    public override bool IsAttack => true;
    protected override string ActionName => "gestures fluidly";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Projectiles.Get(nameof(WaterProjectile));
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DieRoll(monsterLevel * 5 / 2) + 50;
    }
    protected override int Radius => 4;

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        base.ExecuteOnPlayer(game, monster);
        game.MsgPrint("You are engulfed in a whirlpool.");
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        base.ExecuteOnMonster(game, monster, target);
        string targetName = target.Name;
        game.MsgPrint($"{targetName} is engulfed in a whirlpool.");
    }
}
