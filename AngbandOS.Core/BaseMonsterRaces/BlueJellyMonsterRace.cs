using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class BlueJellyMonsterRace : MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Blue jelly";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new ColdAttackEffect(), 1, 6),
        };
        public override bool ColdBlood => true;
        public override string Description => "It's a large pile of pulsing blue flesh.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Blue jelly";
        public override int Hdice => 12;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 4;
        public override int Mexp => 14;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 99;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Blue    ";
        public override string SplitName3 => "   jelly    ";
        public override bool Stupid => true;
    }
}
