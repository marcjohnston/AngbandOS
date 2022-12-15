using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DreadmasterMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new HoldMonsterSpell(),
            new NetherBoltMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportLevelMonsterSpell());
        public override char Character => 'G';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Dreadmaster";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 3, 4)
        };
        public override bool ColdBlood => true;
        public override string Description => "It is an unlife of power almost unequaled. An affront to existence, its very touch abuses and disrupts the flow of life, and its unearthly limbs, of purest black, crush rock and flesh with ease.";
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Dreadmaster";
        public override int Hdice => 12;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 44;
        public override int Mexp => 8000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Dreadmaster ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}
