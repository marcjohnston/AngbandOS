using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantClearCentipedeMonsterRace : MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Giant clear centipede";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Sting, new HurtAttackEffect(), 2, 4),
        };
        public override bool AttrClear => true;
        public override bool BashDoor => true;
        public override string Description => "It is about four feet long and carnivorous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant clear centipede";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool Invisible => true;
        public override int LevelFound => 15;
        public override int Mexp => 30;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   clear    ";
        public override string SplitName3 => " centipede  ";
        public override bool WeirdMind => true;
    }
}
