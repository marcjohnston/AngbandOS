using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ChaosTileMonsterRace : MonsterRace
    {
        protected ChaosTileMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseSeriousWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell(),
            new BlinkMonsterSpell(),
            new SummonMonsterMonsterSpell());
        public override char Character => '·';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos tile";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 3, 4),
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a floor tile corrupted by chaos.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Chaos tile";
        public override int Hdice => 3;
        public override int Hside => 5;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 29;
        public override int Mexp => 200;
        public override bool Multiply => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 30;
        public override int Rarity => 6;
        public override int Sleep => 100;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "    tile    ";
    }
}
