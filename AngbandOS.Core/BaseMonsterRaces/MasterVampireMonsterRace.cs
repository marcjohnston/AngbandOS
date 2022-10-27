using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MasterVampireMonsterRace : MonsterRace
    {
        public override char Character => 'V';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Master vampire";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new Exp40AttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new Exp40AttackEffect(), 1, 4)
        };
        public override bool BashDoor => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "It is a humanoid form dressed in robes. Power emanates from its chilling frame.";
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Master vampire";
        public override int Hdice => 34;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 34;
        public override int Mexp => 750;
        public override bool MindBlast => true;
        public override bool NetherBolt => true;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool Regenerate => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => "  vampire   ";
        public override bool TeleportTo => true;
        public override bool Undead => true;
    }
}
