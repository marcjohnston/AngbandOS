using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ApprenticeRangerMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Green;
        public override string Name => "Apprentice ranger";

        public override int ArmourClass => 6;
        public override bool Arrow3D6 => true;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "An agile hunter, ready and relaxed.";
        public override bool Drop60 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Apprentice Ranger";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 8;
        public override int LevelFound => 8;
        public override bool Male => true;
        public override int Mexp => 18;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Apprentice";
        public override string SplitName3 => "   ranger   ";
    }
}
