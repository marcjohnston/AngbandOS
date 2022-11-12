using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SpottedJellyMonsterRace : MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Spotted jelly";

        public override int ArmourClass => 18;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 1, 10),
        };
        public override bool ColdBlood => true;
        public override string Description => "A jelly thing.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Spotted jelly";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 12;
        public override int Mexp => 33;
        public override bool NeverMove => true;
        public override int NoticeRange => 12;
        public override int Rarity => 3;
        public override int Sleep => 1;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Spotted   ";
        public override string SplitName3 => "   jelly    ";
        public override bool Stupid => true;
    }
}
