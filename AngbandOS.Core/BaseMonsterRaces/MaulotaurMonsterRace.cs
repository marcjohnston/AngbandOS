using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MaulotaurMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Maulotaur";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Butt;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Butt;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect Attack3Effect => new ShatterAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 5;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect Attack4Effect => new ShatterAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "It is a belligrent minotaur with some destructive magical arsenal, armed with a hammer.";
        public override bool Drop60 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Maulotaur";
        public override int Hdice => 250;
        public override int Hside => 10;
        public override bool ImmuneFire => true;
        public override int Level => 50;
        public override int Mexp => 4500;
        public override int NoticeRange => 13;
        public override bool OnlyDropItem => true;
        public override bool PlasmaBolt => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Maulotaur  ";
        public override bool Stupid => true;
    }
}
