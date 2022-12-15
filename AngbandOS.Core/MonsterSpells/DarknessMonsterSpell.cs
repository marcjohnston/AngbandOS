using AngbandOS.Enumerations;
using AngbandOS.Projection;
using AngbandOS.Core.SpellResistantDetections;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class DarknessMonsterSpell : BallProjectileMonsterSpell
    {
        public override bool Annoys => true;

        /// <summary>
        /// Returns the grid and kill projectile flags.
        /// </summary>
        protected override ProjectionFlag ProjectionFlags => ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;

        protected override string ActionName => "gestures in shadow";
        protected override Projectile Projectile(SaveGame saveGame) => new ProjectAcid(saveGame);
        protected override int Damage(Monster monster)
        {
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            return Program.Rng.DieRoll(monsterLevel * 3) + 15;
        }
        public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new AcidSpellResistantDetection() };

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            base.ExecuteOnPlayer(saveGame, monster);
            saveGame.UnlightArea(0, 3);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            base.ExecuteOnMonster(saveGame, monster, target);
            saveGame.UnlightRoom(target.MapY, target.MapX);
        }
    }
}
