using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ChimeraMonsterRace : MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Chimera";

        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Bite, new FireAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Butt, new HurtAttackEffect(), 1, 3),
        };
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "It is a strange concoction of lion, dragon and goat. It looks very odd but very avoidable.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Chimera";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int LevelFound => 20;
        public override int Mexp => 200;
        public override int NoticeRange => 12;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Chimera   ";
    }
}