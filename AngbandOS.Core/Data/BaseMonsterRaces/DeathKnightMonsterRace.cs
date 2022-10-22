using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DeathKnightMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Death knight";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 5;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Exp20;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a humanoid form dressed in armour of an ancient form. From beneath its helmet, eyes glow a baleful red and seem to pierce you like lances of fire.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Death knight";
        public override int Hdice => 60;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override int Level => 38;
        public override int Mexp => 1111;
        public override bool NetherBolt => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Death    ";
        public override string SplitName3 => "   knight   ";
        public override bool SummonMonsters => true;
    }
}
