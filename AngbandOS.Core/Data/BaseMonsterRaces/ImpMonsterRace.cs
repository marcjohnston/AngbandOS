using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ImpMonsterRace : Base2MonsterRace
    {
        public override char Character => 'u';
        public override Colour Colour => Colour.Red;
        public override string Name => "Imp";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new PoisonAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override bool Demon => true;
        public override string Description => "The lawful evil master's favourite pet.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Imp";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override bool Invisible => true;
        public override int Level => 17;
        public override int Mexp => 55;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Imp     ";
        public override bool TeleportLevel => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
    }
}
