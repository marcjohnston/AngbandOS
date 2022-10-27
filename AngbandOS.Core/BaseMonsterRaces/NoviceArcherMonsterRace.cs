using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class NoviceArcherMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Novice archer";

        public override int ArmourClass => 10;
        public override bool Arrow1D6 => true;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "A nasty little fellow with a bow and arrow.";
        public override bool Drop_1D2 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Novice archer";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override int LevelFound => 6;
        public override bool Male => true;
        public override int Mexp => 20;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 5;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Novice   ";
        public override string SplitName3 => "   archer   ";
    }
}
