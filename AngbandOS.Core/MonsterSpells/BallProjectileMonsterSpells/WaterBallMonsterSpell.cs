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
    public override string? VsMonsterSeenMessage => "{0} gestures fluidly at {3}";
    public override string? VsPlayerActionMessage => "{0} gestures fluidly.";
    protected override string ProjectileKey => nameof(WaterProjectile);
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DieRoll(monsterLevel * 5 / 2) + 50;
    }
    protected override int Radius => 4;

    public override void ExecuteOnPlayer(Monster monster)
    {
        base.ExecuteOnPlayer(monster);
        Game.MsgPrint("You are engulfed in a whirlpool.");
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        base.ExecuteOnMonster(monster, target);
        string targetName = target.Name;
        Game.MsgPrint($"{targetName} is engulfed in a whirlpool.");
    }
}
