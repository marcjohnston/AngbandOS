using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FrostGiantMonsterRace : MonsterRace
    {
        public override char Character => 'P';
        public override string Name => "Frost giant";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new ColdAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A twelve foot tall giant covered in furs.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Frost giant";
        public override bool Giant => true;
        public override int Hdice => 17;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override int LevelFound => 15;
        public override bool Male => true;
        public override int Mexp => 75;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Frost    ";
        public override string SplitName3 => "   giant    ";
    }
}
