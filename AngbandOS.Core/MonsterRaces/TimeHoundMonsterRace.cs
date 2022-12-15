using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TimeHoundMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheTimeMonsterSpell());
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Time hound";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override string Description => "You get a terrible sense of deja vu, or is it a premonition? All at once you see a little puppy and a toothless old dog. Perhaps you should give up and go to bed.";
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Time hound";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 51;
        public override int Mexp => 5000;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Time    ";
        public override string SplitName3 => "   hound    ";
    }
}
