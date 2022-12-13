using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FleshGolemMonsterRace : MonsterRace
    {
        public override char Character => 'g';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Flesh golem";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A shambling humanoid monster with long scars.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Flesh golem";
        public override int Hdice => 12;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 14;
        public override int Mexp => 50;
        public override bool Nonliving => true;
        public override int NoticeRange => 12;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Flesh    ";
        public override string SplitName3 => "   golem    ";
    }
}
