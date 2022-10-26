using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlackKnightMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Black knight";

        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override bool Darkness => true;
        public override string Description => "He is a figure encased in deep black plate armour; he looks at you menacingly.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Black knight";
        public override int Hdice => 30;
        public override int Hside => 10;
        public override int Level => 28;
        public override bool Male => true;
        public override int Mexp => 240;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "   knight   ";
    }
}
