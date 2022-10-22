using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheNorsaMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "The Norsa";

        public override int ArmourClass => 125;
        public override int Attack1DDice => 8;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new AcidAttackEffect();
        public override AttackType Attack1Type => AttackType.Crush;
        public override int Attack2DDice => 8;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new FireAttackEffect();
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 8;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new ElectricityAttackEffect();
        public override AttackType Attack3Type => AttackType.Crush;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 14;
        public override BaseAttackEffect? Attack4Effect => new PoisonAttackEffect();
        public override AttackType Attack4Type => AttackType.Crush;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheAcid => true;
        public override bool BreatheCold => true;
        public override bool BreatheFire => true;
        public override bool BreatheLightning => true;
        public override bool BreathePoison => true;
        public override bool Confuse => true;
        public override string Description => "An elephantine horror with five trunks, each capable of breathing destructive blasts of elements.";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "The Norsa";
        public override int Hdice => 100;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 70;
        public override bool LightningAura => true;
        public override int Mexp => 47500;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool Scare => true;
        public override int Sleep => 70;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => "   Norsa    ";
        public override bool SummonHiDragon => true;
        public override bool SummonMonsters => true;
        public override bool Unique => true;
    }
}
