using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TselakusTheDreadlordMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Red;
        public override string Name => "Tselakus, the Dreadlord";

        public override int ArmourClass => 150;
        public override int Attack1DDice => 10;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 10;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.LoseStr;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 4;
        public override int Attack4DSides => 6;
        public override AttackEffect Attack4Effect => AttackEffect.LoseStr;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool Blindness => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override bool DarkBall => true;
        public override string Description => "This huge affront to existence twists and tears at the fabric of space.Darkness itself recoils from the touch of Tselakus as he leaves a trailof death and destruction. Mighty claws rend reality as heannihilates all in his path to your soul!";
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Tselakus, the Dreadlord";
        public override int Hdice => 65;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 68;
        public override bool Male => true;
        public override int Mexp => 35000;
        public override bool NetherBall => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Tselakus  ";
        public override bool SummonHiUndead => true;
        public override bool SummonKin => true;
        public override bool Undead => true;
        public override bool Unique => true;
    }
}
