using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantSalamanderMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell());
        public override char Character => 'R';
        public override Colour Colour => Colour.Red;
        public override string Name => "Giant salamander";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new FireAttackEffect(), 3, 6),
        };
        public override string Description => "A large black and yellow lizard. You'd better run away!";
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Giant salamander";
        public override int Hdice => 6;
        public override int Hside => 7;
        public override bool ImmuneFire => true;
        public override int LevelFound => 8;
        public override int Mexp => 50;
        public override int NoticeRange => 6;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 1;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Giant    ";
        public override string SplitName3 => " salamander ";
    }
}
