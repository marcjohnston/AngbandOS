using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GlaryssaSuccubusQueenMonsterRace : Base2MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Glaryssa, Succubus Queen";

        public override bool AcidBolt => true;
        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Touch, new Exp80AttackEffect(), 8, 1)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override bool Darkness => true;
        public override bool Demon => true;
        public override string Description => "Drop dead gorgeous - literally.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Glaryssa, Succubus Queen";
        public override int Hdice => 12;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmunePoison => true;
        public override int Level => 41;
        public override int Mexp => 8000;
        public override bool MindBlast => true;
        public override bool MoveBody => true;
        public override bool NetherBolt => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Glaryssa  ";
        public override bool SummonDemon => true;
        public override bool Unique => true;
    }
}
