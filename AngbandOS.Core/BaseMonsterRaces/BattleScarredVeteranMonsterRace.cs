using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BattleScarredVeteranMonsterRace : Base2MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.Red;
        public override string Name => "Battle scarred veteran";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "He doesn't take to strangers kindly.";
        public override bool Drop90 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Battle scarred veteran";
        public override int Hdice => 7;
        public override int Hside => 8;
        public override int Level => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 250;
        public override int Speed => 110;
        public override string SplitName1 => "   Battle   ";
        public override string SplitName2 => "  scarred   ";
        public override string SplitName3 => "  veteran   ";
        public override bool TakeItem => true;
    }
}
