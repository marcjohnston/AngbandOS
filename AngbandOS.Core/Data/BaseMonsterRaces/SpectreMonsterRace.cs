using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SpectreMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Spectre";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new TerrifyAttackEffect();
        public override AttackType Attack1Type => AttackType.Wail;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new Exp40AttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 5;
        public override BaseAttackEffect? Attack3Effect => new LoseWisAttackEffect();
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool Blindness => true;
        public override bool ColdBlood => true;
        public override string Description => "A phantasmal shrieking spirit. Its wail drives the intense cold of pure evil deep within your body.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Spectre";
        public override int Hdice => 14;
        public override bool Hold => true;
        public override int Hside => 20;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 33;
        public override int Mexp => 350;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Spectre   ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}
