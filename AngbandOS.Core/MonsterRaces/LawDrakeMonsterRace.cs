using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class LawDrakeMonsterRace : MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Law drake";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override bool BreatheShards => true;
        public override bool BreatheSound => true;
        public override bool Confuse => true;
        public override string Description => "This dragon is clever and cunning. It laughs at your puny efforts to disturb it.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Law drake";
        public override bool Good => true;
        public override int Hdice => 55;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 33;
        public override int Mexp => 700;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Law     ";
        public override string SplitName3 => "   drake    ";
    }
}