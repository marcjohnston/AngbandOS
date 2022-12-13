using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class UndeadMassMonsterRace : MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Undead mass";

        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new PoisonAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Touch, new LoseConAttackEffect(), 1, 6),
        };
        public override bool ColdBlood => true;
        public override string Description => "A sickening mound of decaying flesh, bones, hands and so on. It seems to be growing.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Undead mass";
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 10;
        public override int Mexp => 33;
        public override bool Multiply => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 70;
        public override int Rarity => 2;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Undead   ";
        public override string SplitName3 => "    mass    ";
        public override bool Undead => true;
    }
}
