using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LashaMistressOfWaterMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Lasha, Mistress of Water";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5)
        };
        public override bool BashDoor => true;
        public override bool ColdBall => true;
        public override string Description => "With the body of a beautiful mermaid, she hides her cruelnature well, until it is too late.";
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Lasha, Mistress of Water";
        public override int Hdice => 20;
        public override int Hside => 100;
        public override bool IceBolt => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int Level => 39;
        public override int Mexp => 3250;
        public override int NoticeRange => 12;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Lasha    ";
        public override bool Unique => true;
        public override bool WaterBall => true;
        public override bool WaterBolt => true;
    }
}
