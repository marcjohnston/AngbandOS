using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class UnmakerMonsterRace : MonsterRace
    {
        protected UnmakerMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheChaosMonsterSpell());
        public override char Character => 'E';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Unmaker";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new LoseAllAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Touch, new UnBonusAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 10, 10),
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "Summoned from the planes of Chaos, it is a mass of semi-sentient chaos, spreading uncontrollably and destroying everything in its path.";
        public override bool Drop60 => true;
        public override bool DropGood => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Unmaker";
        public override int Hdice => 6;
        public override int Hside => 66;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override bool KillWall => true;
        public override int LevelFound => 77;
        public override bool LightningAura => true;
        public override int Mexp => 10000;
        public override bool Multiply => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 60;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override bool ResistDisenchant => true;
        public override bool ResistNexus => true;
        public override bool ResistPlasma => true;
        public override bool Shapechanger => true;
        public override int Sleep => 60;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Unmaker   ";
    }
}
