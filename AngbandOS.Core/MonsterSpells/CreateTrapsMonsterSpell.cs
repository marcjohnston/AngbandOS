namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class CreateTrapsMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;
        public override bool Annoys => true;

        public override string? VsPlayerBlindMessage => $"Someone mumbles and then cackles evilly.";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} casts a spell and cackles evilly.";

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
            saveGame.Project(0, 1, saveGame.Player.MapY, saveGame.Player.MapX, 0, new MakeTrapProjectile(saveGame), flg);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
            saveGame.Project(0, 1, target.MapY, target.MapX, 0, new MakeTrapProjectile(saveGame), flg);
        }
    }
}
