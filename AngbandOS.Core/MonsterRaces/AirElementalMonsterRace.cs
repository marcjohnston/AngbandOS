using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AirElementalMonsterRace : MonsterRace
    {
        protected AirElementalMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new LightningBoltMonsterSpell());
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Air elemental";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 1, 4),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a towering tornado of winds.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Air elemental";
        public override int Hdice => 30;
        public override int Hside => 5;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int LevelFound => 34;
        public override int Mexp => 390;
        public override int NoticeRange => 12;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Air     ";
        public override string SplitName3 => " elemental  ";
    }
}
