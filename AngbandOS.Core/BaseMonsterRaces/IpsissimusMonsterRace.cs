using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class IpsissimusMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Red;
        public override string Name => "Ipsissimus";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override string Description => "A gaunt figure, clothed in black robes.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Ipsissimus";
        public override bool Haste => true;
        public override int Hdice => 28;
        public override bool Hold => true;
        public override int Hside => 10;
        public override int Level => 36;
        public override bool Male => true;
        public override int Mexp => 666;
        public override bool MindBlast => true;
        public override bool NetherBolt => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Ipsissimus ";
        public override bool SummonDemon => true;
        public override bool SummonUndead => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
    }
}
