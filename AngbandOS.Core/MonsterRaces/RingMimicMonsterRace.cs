using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RingMimicMonsterRace : MonsterRace
    {
        protected RingMimicMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new AcidBoltMonsterSpell(),
            new BlindnessMonsterSpell(),
            new CauseSeriousWoundsMonsterSpell(),
            new ColdBoltMonsterSpell(),
            new ConfuseMonsterSpell(),
            new FireBoltMonsterSpell(),
            new LightningBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new ForgetMonsterSpell(),
            new SummonMonsterMonsterSpell());
        public override char Character => '=';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Ring mimic";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 3, 4)
        };
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A strange creature that disguises itself as discarded objects to lure unsuspecting adventurers within reach of its venomous claws.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Ring mimic";
        public override int Hdice => 10;
        public override int Hside => 35;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 29;
        public override int Mexp => 200;
        public override bool NeverMove => true;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override int Sleep => 100;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ring    ";
        public override string SplitName3 => "   mimic    ";
    }
}
