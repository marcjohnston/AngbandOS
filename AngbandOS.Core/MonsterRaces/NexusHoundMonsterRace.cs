using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class NexusHoundMonsterRace : MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Nexus hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override bool BreatheNexus => true;
        public override string Description => "A locus of conflicting points coalesce to form the vague shape of a huge hound. Or is it just your imagination?";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Nexus hound";
        public override bool Friends => true;
        public override int Hdice => 25;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 27;
        public override int Mexp => 250;
        public override int NoticeRange => 30;
        public override int Rarity => 3;
        public override bool ResistNexus => true;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Nexus    ";
        public override string SplitName3 => "   hound    ";
    }
}