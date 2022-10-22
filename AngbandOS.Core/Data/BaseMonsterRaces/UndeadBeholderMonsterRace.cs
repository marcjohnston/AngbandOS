using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class UndeadBeholderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Undead beholder";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new Exp40AttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new ParalyzeAttackEffect();
        public override AttackType Attack2Type => AttackType.Gaze;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new LoseIntAttackEffect();
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new UnPowerAttackEffect();
        public override AttackType Attack4Type => AttackType.Gaze;
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "A disembodied eye, floating in the air. Black nether storms rage around its bloodshot pupil and light seems to bend as it sucks its power from the very air around it. Your soul chills as it drains your vitality for its evil enchantments.";
        public override bool DrainMana => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Undead beholder";
        public override int Hdice => 27;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 42;
        public override bool ManaBolt => true;
        public override int Mexp => 4000;
        public override bool MindBlast => true;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Undead   ";
        public override string SplitName3 => "  beholder  ";
        public override bool SummonUndead => true;
        public override bool Undead => true;
    }
}
