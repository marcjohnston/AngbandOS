namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class WaterBallMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool IsAttack => true;
        protected override string ActionName => "gestures fluidly";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectWater(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DieRoll(monsterLevel * 5 / 2) + 50;
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
}
