using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class KillerBrownBeetleMonsterRace : MonsterRace
    {
        public override char Character => 'K';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Killer brown beetle";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a vicious insect with a tough carapace.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer brown beetle";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override int LevelFound => 13;
        public override int Mexp => 38;
        public override int NoticeRange => 10;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Killer   ";
        public override string SplitName2 => "   brown    ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
