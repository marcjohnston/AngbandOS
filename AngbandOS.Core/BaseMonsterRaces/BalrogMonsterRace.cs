using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class BalrogMonsterRace : MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Balrog";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 6),
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 6, 2),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 5)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool BreatheFire => true;
        public override bool Confuse => true;
        public override bool Demon => true;
        public override string Description => "It is a massive humanoid demon wreathed in flames.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Balrog";
        public override int Hdice => 30;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int LevelFound => 50;
        public override int Mexp => 10000;
        public override bool MoveBody => true;
        public override bool NetherBall => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override int Sleep => 80;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Balrog   ";
        public override bool SummonDemon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonUndead => true;
    }
}
