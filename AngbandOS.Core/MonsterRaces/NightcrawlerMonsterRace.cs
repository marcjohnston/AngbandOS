using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class NightcrawlerMonsterRace : MonsterRace
    {
        public override char Character => 'z';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nightcrawler";

        public override int ArmourClass => 160;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Sting, new LoseConAttackEffect(), 8, 8),
            new MonsterAttack(AttackType.Sting, new LoseConAttackEffect(), 8, 8),
            new MonsterAttack(AttackType.Bite, new AcidAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Bite, new AcidAttackEffect(), 10, 10)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool BreatheNether => true;
        public override bool ColdBlood => true;
        public override string Description => "This intensely evil creature bears the form of a gargantuan black worm. Its gaping maw is a void of blackness, acid drips from its steely hide. It is like nothing you have ever seen before, and a terrible chill runs down your spine as you face it.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Nightcrawler";
        public override int Hdice => 80;
        public override int Hside => 60;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int LevelFound => 54;
        public override bool ManaBolt => true;
        public override int Mexp => 8100;
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
        public override string SplitName3 => "Nightcrawler";
        public override bool SummonUndead => true;
        public override bool Undead => true;
    }
}