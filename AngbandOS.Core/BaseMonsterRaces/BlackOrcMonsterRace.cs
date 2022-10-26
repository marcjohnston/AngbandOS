using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlackOrcMonsterRace : Base2MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Black;
        public override string Name => "Black orc";

        public override int ArmourClass => 36;
        public override bool Arrow1D6 => true;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "He is a large orc with powerful arms and deep black skin.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Black orc";
        public override bool Friends => true;
        public override int Hdice => 12;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override int Level => 13;
        public override bool Male => true;
        public override int Mexp => 45;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "    orc     ";
    }
}
