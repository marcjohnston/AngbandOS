using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class WhiteWraithMonsterRace : MonsterRace
    {
        public override char Character => 'W';
        public override string Name => "White wraith";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Touch, new Exp20AttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override bool CauseSeriousWounds => true;
        public override bool ColdBlood => true;
        public override bool Darkness => true;
        public override string Description => "It is a tangible but ghostly form made of white fog.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "White wraith";
        public override int Hdice => 15;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 26;
        public override int Mexp => 175;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   White    ";
        public override string SplitName3 => "   wraith   ";
        public override bool Undead => true;
    }
}