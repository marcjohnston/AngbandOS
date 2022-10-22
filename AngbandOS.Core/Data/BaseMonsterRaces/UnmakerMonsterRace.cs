using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class UnmakerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Unmaker";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 10;
        public override int Attack1DSides => 10;
        public override BaseAttackEffect? Attack1Effect => new LoseAllAttackEffect();
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 10;
        public override int Attack2DSides => 10;
        public override BaseAttackEffect? Attack2Effect => new UnBonusAttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 10;
        public override BaseAttackEffect? Attack3Effect => new UnPowerAttackEffect();
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BreatheChaos => true;
        public override bool ColdBlood => true;
        public override string Description => "Summoned from the planes of Chaos, it is a mass of semi-sentient chaos, spreading uncontrollably and destroying everything in its path.";
        public override bool Drop60 => true;
        public override bool DropGood => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Unmaker";
        public override int Hdice => 6;
        public override int Hside => 66;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override bool KillWall => true;
        public override int Level => 77;
        public override bool LightningAura => true;
        public override int Mexp => 10000;
        public override bool Multiply => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 60;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override bool ResistDisenchant => true;
        public override bool ResistNexus => true;
        public override bool ResistPlasma => true;
        public override bool Shapechanger => true;
        public override int Sleep => 60;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Unmaker   ";
    }
}
