using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class EarthElementalMonsterRace : MonsterRace
    {
        protected EarthElementalMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new AcidBoltMonsterSpell());
        public override char Character => 'E';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Earth elemental";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
        };
        public override bool ColdBlood => true;
        public override string Description => "It is a towering form composed of rock with fists of awesome power.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Earth elemental";
        public override int Hdice => 30;
        public override int Hside => 10;
        public override bool HurtByRock => true;
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
        public override int Mexp => 375;
        public override int NoticeRange => 10;
        public override bool PassWall => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 90;
        public override int Speed => 100;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Earth    ";
        public override string SplitName3 => " elemental  ";
    }
}
