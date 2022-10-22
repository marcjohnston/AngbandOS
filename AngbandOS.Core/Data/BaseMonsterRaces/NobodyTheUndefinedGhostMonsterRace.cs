using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class NobodyTheUndefinedGhostMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override string Name => "Nobody, the Undefined Ghost";

        public override int ArmourClass => 0;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => null;
        public override AttackType Attack1Type => AttackType.Nothing;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => null;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "It seems strangely familiar...";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Nobody, the Undefined Ghost";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override int Level => 127;
        public override int Mexp => 1;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 0;
        public override int Rarity => 0;
        public override int Sleep => 0;
        public override int Speed => 0;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Nobody   ";
        public override bool Unique => true;
    }
}
