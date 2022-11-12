using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GromMasterOfEarthMonsterRace : MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Grom, Master of Earth";

        public override bool AcidBall => true;
        public override bool AcidBolt => true;
        public override int ArmourClass => 97;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new ShatterAttackEffect(), 10, 10)
        };
        public override bool ColdBlood => true;
        public override string Description => "A towering stone elemental stands before you. The walls and ceiling are reduced to rubble as Grom advances.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Grom, Master of Earth";
        public override int Hdice => 18;
        public override int Hside => 100;
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
        public override bool KillWall => true;
        public override int LevelFound => 43;
        public override bool Male => true;
        public override int Mexp => 6000;
        public override int NoticeRange => 10;
        public override bool PassWall => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Grom    ";
        public override bool Unique => true;
    }
}
