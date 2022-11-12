using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantBrownBatMonsterRace : MonsterRace
    {
        public override char Character => 'b';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Giant brown bat";

        public override bool Animal => true;
        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 3),
        };
        public override string Description => "It screeches as it attacks.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant brown bat";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override int LevelFound => 6;
        public override int Mexp => 10;
        public override int NoticeRange => 10;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 130;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   brown    ";
        public override string SplitName3 => "    bat     ";
    }
}
