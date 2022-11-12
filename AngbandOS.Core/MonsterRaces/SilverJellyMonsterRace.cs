using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SilverJellyMonsterRace : MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Silver jelly";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new EatLightAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Touch, new EatLightAttackEffect(), 1, 3),
        };
        public override string Description => "It is a large pile of silver flesh that sucks all light from its surroundings.";
        public override bool DrainMana => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Silver jelly";
        public override int Hdice => 10;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 3;
        public override int Mexp => 12;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 2;
        public override int Sleep => 99;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Silver   ";
        public override string SplitName3 => "   jelly    ";
        public override bool Stupid => true;
    }
}
