using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DrolemMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new Arrow5D6MonsterSpell(),
            new BreathePoisonMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new SlowMonsterSpell());
        public override char Character => 'g';
        public override Colour Colour => Colour.Green;
        public override string Name => "Drolem";

        public override int ArmourClass => 130;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 5, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 5, 8),
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 3, 3),
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A constructed dragon, the drolem has massive strength. Powerful spells weaved during its creation make it a fearsome adversary. Its eyes show little intelligence, but it has been instructed to destroy all it meets.";
        public override bool Dragon => true;
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Drolem";
        public override int Hdice => 30;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 44;
        public override int Mexp => 12000;
        public override bool Nonliving => true;
        public override int NoticeRange => 25;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Drolem   ";
    }
}
