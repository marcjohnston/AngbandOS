using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OgreShamanMonsterRace : Base2MonsterRace
    {
        public override char Character => 'O';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Ogre shaman";

        public override int ArmourClass => 55;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 6),
        };
        public override bool BashDoor => true;
        public override bool CauseSeriousWounds => true;
        public override bool CreateTraps => true;
        public override string Description => "It is an ogre wrapped in furs and covered in grotesque body paints.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Ogre shaman";
        public override bool Giant => true;
        public override int Hdice => 14;
        public override bool Hold => true;
        public override int Hside => 10;
        public override int Level => 32;
        public override int Mexp => 250;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ogre    ";
        public override string SplitName3 => "   shaman   ";
        public override bool SummonMonster => true;
        public override bool TeleportSelf => true;
    }
}
