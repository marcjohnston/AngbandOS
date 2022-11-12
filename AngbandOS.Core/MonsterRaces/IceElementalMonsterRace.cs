using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class IceElementalMonsterRace : MonsterRace
    {
        public override char Character => 'E';
        public override string Name => "Ice elemental";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 1, 3),
        };
        public override bool BashDoor => true;
        public override bool ColdBall => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a towering glacier of ice.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Ice elemental";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool IceBolt => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int LevelFound => 36;
        public override int Mexp => 650;
        public override int NoticeRange => 10;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ice     ";
        public override string SplitName3 => " elemental  ";
    }
}
