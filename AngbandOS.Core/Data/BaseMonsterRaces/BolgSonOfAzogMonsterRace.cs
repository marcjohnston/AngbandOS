using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BolgSonOfAzogMonsterRace : Base2MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Bolg, Son of Azog";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "A large and powerful orc. He looks just like his daddy. He is tall and fast, but fortunately blessed with orcish brains.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Bolg, Son of Azog";
        public override int Hdice => 50;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int Level => 20;
        public override bool Male => true;
        public override int Mexp => 800;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 4;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Bolg    ";
        public override bool Unique => true;
    }
}
