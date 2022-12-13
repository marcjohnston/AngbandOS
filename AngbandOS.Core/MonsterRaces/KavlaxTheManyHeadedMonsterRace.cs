using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class KavlaxTheManyHeadedMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell(),
            new BreatheColdMonsterSpell(),
            new BreatheConfusionMonsterSpell(),
            new BreatheLightningMonsterSpell(),
            new BreatheFireMonsterSpell(),
            new BreatheGravityMonsterSpell(),
            new BreatheNexusMonsterSpell(),
            new BreatheShardsMonsterSpell(),
            new BreatheSoundMonsterSpell());
        public override char Character => 'd';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Kavlax the Many-Headed";

        public override int ArmourClass => 85;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12)
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "A large dragon with a selection of heads, all shouting and arguing as they look for prey, but each with its own deadly breath weapon.";
        public override bool Dragon => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Kavlax the Many-Headed";
        public override int Hdice => 13;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 39;
        public override bool Male => true;
        public override int Mexp => 3000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool ResistNexus => true;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "   Kavlax   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "Many-Headed ";
        public override bool Unique => true;
    }
}
