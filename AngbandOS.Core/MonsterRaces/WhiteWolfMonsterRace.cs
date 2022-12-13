using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WhiteWolfMonsterRace : MonsterRace
    {
        public override char Character => 'C';
        public override string Name => "White wolf";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 3),
        };
        public override bool BashDoor => true;
        public override string Description => "A large and muscled wolf from the northern wastes. Its breath is cold and icy and its fur coated in frost.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "White wolf";
        public override bool Friends => true;
        public override int Hdice => 7;
        public override int Hside => 7;
        public override bool ImmuneCold => true;
        public override int LevelFound => 12;
        public override int Mexp => 30;
        public override int NoticeRange => 30;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   White    ";
        public override string SplitName3 => "    wolf    ";
    }
}
