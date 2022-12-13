using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FilthyStreetUrchinMonsterRace : MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Filthy street urchin";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Beg, null, 0, 0),
            new MonsterAttack(AttackType.Touch, new EatGoldAttackEffect(), 0, 0),
        };
        public override string Description => "He looks squalid and thoroughly revolting.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Filthy street urchin";
        public override bool Friends => true;
        public override int Hdice => 1;
        public override int Hside => 4;
        public override int LevelFound => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 4;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Filthy   ";
        public override string SplitName2 => "   street   ";
        public override string SplitName3 => "   urchin   ";
        public override bool TakeItem => true;
    }
}
