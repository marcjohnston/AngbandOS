using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class CaveLizardMonsterRace : MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Cave lizard";

        public override bool Animal => true;
        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 5),
        };
        public override string Description => "It is an armoured lizard with a powerful bite.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Cave lizard";
        public override int Hdice => 3;
        public override int Hside => 6;
        public override int LevelFound => 4;
        public override int Mexp => 8;
        public override int NoticeRange => 8;
        public override int Rarity => 1;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Cave    ";
        public override string SplitName3 => "   lizard   ";
    }
}
