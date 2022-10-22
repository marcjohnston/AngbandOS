using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FatherDagonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.BrightChartreuse;
        public override string Name => "Father Dagon";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Poison;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.Poison;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool Confuse => true;
        public override bool Cthuloid => true;
        public override bool Demon => true;
        public override string Description => "A scale-skinned humanoid fish, the ruler of deep ones.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Father Dagon";
        public override bool GreatOldOne => true;
        public override int Hdice => 40;
        public override int Hside => 12;
        public override bool ImmuneFire => true;
        public override bool Invisible => true;
        public override int Level => 28;
        public override bool Male => true;
        public override int Mexp => 750;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 5;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Father   ";
        public override string SplitName3 => "   Dagon    ";
        public override bool SummonCthuloid => true;
        public override bool TeleportAway => true;
        public override bool TeleportLevel => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
