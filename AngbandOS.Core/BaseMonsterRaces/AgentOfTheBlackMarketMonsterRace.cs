using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class AgentOfTheBlackMarketMonsterRace : Base2MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.Black;
        public override string Name => "Agent of the black market";

        public override int ArmourClass => 8;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Touch, new EatItemAttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override string Description => "He 'finds' new wares for the Black Market. From unwary adventurers...";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Agent of the black market";
        public override int Hdice => 2;
        public override int Hside => 8;
        public override int Level => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 99;
        public override int Speed => 110;
        public override string SplitName1 => "  Agent of  ";
        public override string SplitName2 => " the black  ";
        public override string SplitName3 => "   market   ";
        public override bool TakeItem => true;
    }
}
