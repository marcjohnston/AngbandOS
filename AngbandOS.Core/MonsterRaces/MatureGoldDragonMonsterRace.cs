using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MatureGoldDragonMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheSoundMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'd';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Mature gold dragon";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
        };
        public override bool BashDoor => true;
        public override string Description => "A large dragon with scales of gleaming gold.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Mature gold dragon";
        public override int Hdice => 56;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 37;
        public override int Mexp => 1500;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override int Sleep => 150;
        public override int Speed => 110;
        public override string SplitName1 => "   Mature   ";
        public override string SplitName2 => "    gold    ";
        public override string SplitName3 => "   dragon   ";
    }
}
