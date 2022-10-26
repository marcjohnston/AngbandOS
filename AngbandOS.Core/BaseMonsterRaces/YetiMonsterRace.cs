using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class YetiMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Y';
        public override string Name => "Yeti";

        public override bool Animal => true;
        public override int ArmourClass => 24;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "A large white figure covered in shaggy fur.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Yeti";
        public override int Hdice => 11;
        public override int Hside => 9;
        public override bool ImmuneCold => true;
        public override int Level => 9;
        public override int Mexp => 30;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Yeti    ";
    }
}
