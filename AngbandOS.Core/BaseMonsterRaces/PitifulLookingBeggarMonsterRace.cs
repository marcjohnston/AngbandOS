using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class PitifulLookingBeggarMonsterRace : Base2MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Pitiful looking beggar";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Beg, null, 0, 0),
        };
        public override string Description => "You just can't help feeling sorry for him.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Pitiful looking beggar";
        public override int Hdice => 1;
        public override int Hside => 4;
        public override int Level => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "  Pitiful   ";
        public override string SplitName2 => "  looking   ";
        public override string SplitName3 => "   beggar   ";
        public override bool TakeItem => true;
    }
}
