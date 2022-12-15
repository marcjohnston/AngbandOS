using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantGreenDragonFlyMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreathePoisonMonsterSpell());
        public override char Character => 'F';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Giant green dragon fly";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A vast, foul-smelling dragonfly.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Giant green dragon fly";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override bool ImmunePoison => true;
        public override int LevelFound => 16;
        public override int Mexp => 70;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "Giant green ";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
