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
    private WaterBallMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsAttack => true;
    protected override string ActionName => "gestures fluidly";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<WaterProjectile>();
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return SaveGame.Rng.DieRoll(monsterLevel * 5 / 2) + 50;
    }
    protected override int Radius => 4;

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        base.ExecuteOnPlayer(saveGame, monster);
        saveGame.MsgPrint("You are engulfed in a whirlpool.");
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        base.ExecuteOnMonster(saveGame, monster, target);
        string targetName = target.Name;
        saveGame.MsgPrint($"{targetName} is engulfed in a whirlpool.");
    }
}
