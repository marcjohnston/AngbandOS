using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SpectralTyrannosaurMonsterRace : Base2MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.Turquoise;
        public override string Name => "Spectral tyrannosaur";

        public override bool Animal => true;
        public override int ArmourClass => 120;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 13;
        public override AttackEffect Attack1Effect => AttackEffect.Exp40;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 13;
        public override AttackEffect Attack2Effect => AttackEffect.Exp40;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.LoseStr;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Terrify;
        public override AttackType Attack4Type => AttackType.Gaze;
        public override bool BashDoor => true;
        public override bool BreatheNether => true;
        public override bool BreatheNexus => true;
        public override bool BreathePoison => true;
        public override string Description => "A deadly undead horror which looks like a skeletal tyrannosaur surrounded by a sickly green glow.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Spectral tyrannosaur";
        public override int Hdice => 70;
        public override bool Hold => true;
        public override int Hside => 50;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 46;
        public override int Mexp => 15000;
        public override bool MoveBody => true;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistNexus => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Spectral  ";
        public override string SplitName3 => "tyrannosaur ";
        public override bool Undead => true;
    }
}
