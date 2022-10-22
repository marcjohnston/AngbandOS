using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class UrukMonsterRace : Base2MonsterRace
    {
        public override char Character => 'o';
        public override string Name => "Uruk";

        public override int ArmourClass => 50;
        public override bool Arrow1D6 => true;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "He is a cunning orc of power, as tall as a man, and stronger. He fears little.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Uruk";
        public override bool Friends => true;
        public override int Hdice => 8;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int Level => 18;
        public override bool Male => true;
        public override int Mexp => 68;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Uruk    ";
    }
}
