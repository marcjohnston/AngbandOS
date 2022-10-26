using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class NetherWraithMonsterRace : Base2MonsterRace
    {
        public override char Character => 'W';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Nether wraith";

        public override int ArmourClass => 55;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Touch, new Exp80AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new Exp80AttackEffect(), 0, 0)
        };
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override bool Darkness => true;
        public override string Description => "A form that hurts the eye, death permeates the air around it. As it nears you, a coldness saps your soul.";
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Nether wraith";
        public override int Hdice => 48;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 39;
        public override int Mexp => 1700;
        public override bool MindBlast => true;
        public override bool NetherBolt => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Nether   ";
        public override string SplitName3 => "   wraith   ";
        public override bool Undead => true;
    }
}
