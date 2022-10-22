using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DeathWatchBeetleMonsterRace : Base2MonsterRace
    {
        public override char Character => 'K';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Death watch beetle";

        public override bool Animal => true;
        public override int ArmourClass => 60;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new TerrifyAttackEffect();
        public override AttackType Attack2Type => AttackType.Wail;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is a giant beetle that produces a chilling sound.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Death watch beetle";
        public override int Hdice => 25;
        public override int Hside => 12;
        public override int Level => 31;
        public override int Mexp => 190;
        public override int NoticeRange => 16;
        public override int Rarity => 3;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Death    ";
        public override string SplitName2 => "   watch    ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
