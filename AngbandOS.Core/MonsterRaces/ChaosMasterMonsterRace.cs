using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ChaosMasterMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos master";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 2),
            new MonsterAttack(AttackType.Kick, new HurtAttackEffect(), 10, 2),
            new MonsterAttack(AttackType.Punch, new HurtAttackEffect(), 10, 2),
            new MonsterAttack(AttackType.Kick, new HurtAttackEffect(), 10, 2)
        };
        public override bool AttrAny => true;
        public override bool BashDoor => true;
        public override bool ChaosBall => true;
        public override string Description => "An adept of chaos, feared for his skill of invoking raw chaos.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Chaos master";
        public override int Hdice => 30;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 33;
        public override bool Male => true;
        public override int Mexp => 550;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 5;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "   master   ";
        public override bool SummonDemon => true;
        public override bool SummonSpider => true;
    }
}