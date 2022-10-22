using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LordOfChaosMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Lord of Chaos";

        public override int ArmourClass => 80;
        public override int Attack1DDice => 20;
        public override int Attack1DSides => 2;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Kick;
        public override int Attack2DDice => 10;
        public override int Attack2DSides => 2;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Kick;
        public override int Attack3DDice => 20;
        public override int Attack3DSides => 1;
        public override BaseAttackEffect? Attack3Effect => new PoisonAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 15;
        public override int Attack4DSides => 1;
        public override BaseAttackEffect? Attack4Effect => new LoseAllAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool ChaosBall => true;
        public override string Description => "He is one of the few true masters of the art, being extremely skillful in all forms of unarmed combat and controlling the chaos with disdainful ease.";
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Lord of Chaos";
        public override int Hdice => 45;
        public override bool Heal => true;
        public override int Hside => 55;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 53;
        public override bool Male => true;
        public override int Mexp => 17500;
        public override bool MindBlast => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Shapechanger => true;
        public override int Sleep => 5;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "    Lord    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "   Chaos    ";
        public override bool SummonDemon => true;
        public override bool SummonHound => true;
        public override bool SummonSpider => true;
    }
}
