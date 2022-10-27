using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class AncalagonTheBlackMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Black;
        public override string Name => "Ancalagon the Black";

        public override int ArmourClass => 125;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 5, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 6, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 10, 14)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheAcid => true;
        public override bool Confuse => true;
        public override string Description => "'Rushing Jaws' is his name, and death is his game. No dragon of the brood of Glaurung can match him.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Ancalagon the Black";
        public override int Hdice => 75;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 58;
        public override bool Male => true;
        public override int Mexp => 30000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 70;
        public override int Speed => 120;
        public override string SplitName1 => " Ancalagon  ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "   Black    ";
        public override bool SummonDragon => true;
        public override bool SummonHiDragon => true;
        public override bool Unique => true;
    }
}
