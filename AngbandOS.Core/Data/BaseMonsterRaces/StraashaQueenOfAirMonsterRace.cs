using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class StraashaQueenOfAirMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Straasha, Queen of Air";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new ConfuseAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 4;
        public override BaseAttackEffect? Attack4Effect => new ConfuseAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool ColdBall => true;
        public override bool ColdBlood => true;
        public override string Description => "A towering air elemental, Straasha, the sorceress, avoids your blows with her extreme speed.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Straasha, Queen of Air";
        public override int Hdice => 27;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int Level => 44;
        public override bool LightningAura => true;
        public override bool LightningBall => true;
        public override bool LightningBolt => true;
        public override int Mexp => 8000;
        public override int NoticeRange => 12;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 4;
        public override int Sleep => 50;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Straasha  ";
        public override bool Unique => true;
    }
}
