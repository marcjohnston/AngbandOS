using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MedusaTheGorgonMonsterRace : MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Medusa, the Gorgon";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new Exp80AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 8, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 8, 6)
        };
        public override bool BashDoor => true;
        public override bool CauseCriticalWounds => true;
        public override string Description => "Her face could sink a thousand ships.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Medusa, the Gorgon";
        public override int Hdice => 24;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 40;
        public override int Mexp => 9000;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override bool PoisonBall => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 5;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Medusa   ";
        public override bool SummonHydra => true;
        public override bool Unique => true;
    }
}