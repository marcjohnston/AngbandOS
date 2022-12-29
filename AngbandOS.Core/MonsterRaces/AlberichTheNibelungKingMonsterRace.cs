using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AlberichTheNibelungKingMonsterRace : MonsterRace
    {
        protected AlberichTheNibelungKingMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new AcidBallMonsterSpell(),
            new AcidBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new HealMonsterSpell(),
            new SummonMonsterMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'h';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Alberich, the Nibelung King";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 3, 12),
            new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 3, 12),
            new MonsterAttack(new TouchAttackType(), new EatGoldAttackEffect(), 0, 0),
            new MonsterAttack(new TouchAttackType(), new EatGoldAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override string Description => "Made invisible with his magic, the greedy dwarf plots for world domination through his riches.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Alberich, the Nibelung King";
        public override int Hdice => 80;
        public override int Hside => 11;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 27;
        public override bool Male => true;
        public override int Mexp => 1000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override bool ResistDisenchant => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Alberich  ";
        public override bool Unique => true;
    }
}
