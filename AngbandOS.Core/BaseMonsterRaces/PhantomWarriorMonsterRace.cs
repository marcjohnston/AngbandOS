using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class PhantomWarriorMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.BrightTurquoise;
        public override string Name => "Phantom warrior";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 11),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 11),
        };
        public override bool ColdBlood => true;
        public override string Description => "Creatures that are half real, half illusion.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Phantom warrior";
        public override bool Friends => true;
        public override int Hdice => 5;
        public override int Hside => 5;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int Level => 8;
        public override int Mexp => 15;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool PassWall => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Phantom   ";
        public override string SplitName3 => "  warrior   ";
    }
}
