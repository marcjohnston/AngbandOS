using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class WormtongueAgentOfSarumanMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Wormtongue, Agent of Saruman";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Touch, new EatGoldAttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override bool ColdBolt => true;
        public override bool CreateTraps => true;
        public override string Description => "He's been spying for Saruman. He is a snivelling wretch with no morals.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Wormtongue, Agent of Saruman";
        public override int Hdice => 25;
        public override bool Heal => true;
        public override int Hside => 10;
        public override int LevelFound => 8;
        public override bool Male => true;
        public override int Mexp => 150;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PoisonBall => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Wormtongue ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}