using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BrownYeekMonsterRace : MonsterRace
    {
        protected BrownYeekMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'y';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Brown yeek";

        public override bool Animal => true;
        public override int ArmourClass => 18;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a strange small humanoid.";
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Brown yeek";
        public override int Hdice => 4;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 8;
        public override int Mexp => 11;
        public override int NoticeRange => 18;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Brown    ";
        public override string SplitName3 => "    yeek    ";
    }
}
