using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShuddeMellMonsterRace : Base2MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Shudde M'ell";

        public override int ArmourClass => 90;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 11;
        public override BaseAttackEffect? Attack1Effect => new ShatterAttackEffect();
        public override AttackType Attack1Type => AttackType.Crush;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 11;
        public override BaseAttackEffect? Attack2Effect => new ShatterAttackEffect();
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 2;
        public override BaseAttackEffect? Attack3Effect => new LoseConAttackEffect();
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 2;
        public override BaseAttackEffect? Attack4Effect => new LoseConAttackEffect();
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool BrainSmash => true;
        public override bool Confuse => true;
        public override bool Cthuloid => true;
        public override string Description => "The largest of the cthonians and leader of his kind.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool Forget => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Shudde M'ell";
        public override bool Haste => true;
        public override int Hdice => 100;
        public override bool Heal => true;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool KillWall => true;
        public override int Level => 56;
        public override int Mexp => 2300;
        public override bool MindBlast => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override int Rarity => 2;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Shudde   ";
        public override string SplitName3 => "   M'ell    ";
        public override bool SummonCthuloid => true;
        public override bool Unique => true;
    }
}
