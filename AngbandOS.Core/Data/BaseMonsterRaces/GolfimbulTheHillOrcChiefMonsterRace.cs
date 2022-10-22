using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GolfimbulTheHillOrcChiefMonsterRace : Base2MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Copper;
        public override string Name => "Golfimbul, the Hill Orc Chief";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "A leader of a band of raiding orcs, he picks on hobbits.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Golfimbul, the Hill Orc Chief";
        public override int Hdice => 24;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override int Level => 12;
        public override bool Male => true;
        public override int Mexp => 230;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Golfimbul  ";
        public override bool Unique => true;
    }
}
