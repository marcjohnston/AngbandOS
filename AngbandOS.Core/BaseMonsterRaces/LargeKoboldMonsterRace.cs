using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LargeKoboldMonsterRace : Base2MonsterRace
    {
        public override char Character => 'k';
        public override string Name => "Large kobold";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
        };
        public override bool BashDoor => true;
        public override string Description => "It a man-sized figure with the all too recognizable face of a kobold.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Large kobold";
        public override int Hdice => 13;
        public override int Hside => 9;
        public override bool ImmunePoison => true;
        public override int Level => 5;
        public override int Mexp => 25;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Large    ";
        public override string SplitName3 => "   kobold   ";
    }
}
