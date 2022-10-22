using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheEmissaryMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Orange;
        public override string Name => "The Emissary";

        public override int ArmourClass => 40;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 5;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 5;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 5;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => new TerrifyAttackEffect();
        public override AttackType Attack4Type => AttackType.Gaze;
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "The Emmisary can pass for human and is used by her demonic overlords to infiltrate human society and gather information. Only her eyes give away her demonic nature.";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "The Emissary";
        public override int Hdice => 34;
        public override int Hside => 10;
        public override int Level => 16;
        public override int Mexp => 200;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => "  Emissary  ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}
