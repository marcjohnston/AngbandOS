using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GhostMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new DrainManaMonsterSpell(),
            new HoldMonsterSpell());
        public override char Character => 'G';
        public override string Name => "Ghost";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Wail, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new Exp20AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Claw, new LoseIntAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Claw, new LoseWisAttackEffect(), 1, 6)
        };
        public override bool ColdBlood => true;
        public override string Description => "You don't believe in them.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Ghost";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 31;
        public override int Mexp => 350;
        public override int NoticeRange => 20;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Ghost    ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}
