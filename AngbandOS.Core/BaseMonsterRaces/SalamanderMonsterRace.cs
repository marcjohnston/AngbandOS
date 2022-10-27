using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class SalamanderMonsterRace : MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Salamander";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new FireAttackEffect(), 1, 3),
        };
        public override string Description => "A small black and orange lizard.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Salamander";
        public override int Hdice => 4;
        public override int Hside => 6;
        public override bool ImmuneFire => true;
        public override int LevelFound => 2;
        public override int Mexp => 10;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Salamander ";
    }
}
