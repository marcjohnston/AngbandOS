using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class PhaseSpiderMonsterRace : MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Phase spider";

        public override bool Animal => true;
        public override int ArmourClass => 25;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override string Description => "A spider that never seems quite there. Everywhere you look it is just half-seen in the corner of one eye.";
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Phase spider";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool ImmunePoison => true;
        public override int LevelFound => 20;
        public override int Mexp => 60;
        public override int NoticeRange => 15;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Phase    ";
        public override string SplitName3 => "   spider   ";
        public override bool TeleportTo => true;
        public override bool WeirdMind => true;
    }
}