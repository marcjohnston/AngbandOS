using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BastGoddessOfCatsMonsterRace : Base2MonsterRace
    {
        public override char Character => 'f';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Bast, Goddess of Cats";

        public override int ArmourClass => 200;
        public override int Attack1DDice => 12;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new ConfuseAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new LoseDexAttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 5;
        public override BaseAttackEffect? Attack3Effect => new BlindAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 15;
        public override int Attack4DSides => 1;
        public override BaseAttackEffect? Attack4Effect => new ParalyzeAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "She looks like a mortal female with a cat's head.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Bast, Goddess of Cats";
        public override int Hdice => 48;
        public override bool Heal => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 64;
        public override int Mexp => 30500;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Bast    ";
        public override bool SummonKin => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
