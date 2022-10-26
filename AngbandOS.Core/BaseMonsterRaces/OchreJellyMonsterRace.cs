using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OchreJellyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Ochre jelly";

        public override int ArmourClass => 18;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 1, 10),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A fast moving highly acidic jelly thing, that is eating away the floor it rests on.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Ochre jelly";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 13;
        public override int Mexp => 40;
        public override int NoticeRange => 12;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 1;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Ochre    ";
        public override string SplitName3 => "   jelly    ";
        public override bool Stupid => true;
        public override bool TakeItem => true;
    }
}
