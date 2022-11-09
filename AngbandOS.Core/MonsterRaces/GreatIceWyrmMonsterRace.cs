using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GreatIceWyrmMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override string Name => "Great ice wyrm";

        public override int ArmourClass => 170;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 5, 14)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheCold => true;
        public override bool Confuse => true;
        public override string Description => "An immense dragon capable of awesome destruction. You have never felt such extreme cold, or witnessed such an icy stare. Begone quickly or feel its wrath!";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Great ice wyrm";
        public override int Hdice => 30;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 54;
        public override int Mexp => 20000;
        public override bool MoveBody => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "   Great    ";
        public override string SplitName2 => "    ice     ";
        public override string SplitName3 => "    wyrm    ";
    }
}
