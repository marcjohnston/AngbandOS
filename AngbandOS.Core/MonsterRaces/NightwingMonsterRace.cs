using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class NightwingMonsterRace : MonsterRace
    {
        public override char Character => 'z';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nightwing";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new PoisonAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Touch, new PoisonAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 6, 8),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 6, 8)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "Everywhere colours seem paler and the air chiller. At the centre of the cold stands a mighty figure. Its wings envelop you in the chill of death as the nightwing reaches out to draw you into oblivion. Your muscles sag and your mind loses all will to fight as you stand in awe of this mighty being.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Nightwing";
        public override int Hdice => 60;
        public override int Hside => 30;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 50;
        public override bool ManaBolt => true;
        public override int Mexp => 6000;
        public override bool NetherBall => true;
        public override bool NetherBolt => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Nightwing  ";
        public override bool SummonUndead => true;
        public override bool Undead => true;
    }
}