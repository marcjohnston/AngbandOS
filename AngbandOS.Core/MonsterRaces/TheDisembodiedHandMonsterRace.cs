using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class TheDisembodiedHandMonsterRace : MonsterRace
    {
        public override char Character => 'z';
        public override Colour Colour => Colour.Green;
        public override string Name => "The disembodied hand";

        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "Even today, nobody knows where it lurks... ";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "The disembodied hand";
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 6;
        public override int Mexp => 20;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 130;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "disembodied ";
        public override string SplitName3 => "    hand    ";
        public override bool Undead => true;
        public override bool Unique => true;
    }
}