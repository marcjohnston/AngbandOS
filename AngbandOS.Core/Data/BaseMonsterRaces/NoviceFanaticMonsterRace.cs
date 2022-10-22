using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class NoviceFanaticMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override string Name => "Novice fanatic";

        public override int ArmourClass => 16;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 7;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 7;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool CauseLightWounds => true;
        public override string Description => "He thinks you are an agent of the devil. ";
        public override bool Drop60 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Novice fanatic";
        public override bool Friends => true;
        public override bool Good => true;
        public override int Hdice => 6;
        public override int Hside => 8;
        public override int Level => 8;
        public override bool Male => true;
        public override int Mexp => 20;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Novice   ";
        public override string SplitName3 => "  fanatic   ";
    }
}
