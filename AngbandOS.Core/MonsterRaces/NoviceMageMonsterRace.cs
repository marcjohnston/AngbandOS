using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NoviceMageMonsterRace : MonsterRace
    {
        protected NoviceMageMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new MagicMissileMonsterSpell(),
            new BlinkMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Novice mage";

        public override int ArmourClass => 6;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "He is leaving behind a trail of dropped spell components.";
        public override bool Drop60 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Novice mage";
        public override int Hdice => 6;
        public override int Hside => 4;
        public override int LevelFound => 2;
        public override bool Male => true;
        public override int Mexp => 7;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Novice   ";
        public override string SplitName3 => "    mage    ";
    }
}
