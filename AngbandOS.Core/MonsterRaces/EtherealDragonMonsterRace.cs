using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class EtherealDragonMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Ethereal dragon";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 6, 12),
        };
        public override bool Blindness => true;
        public override bool BreatheConfusion => true;
        public override bool BreatheDark => true;
        public override bool BreatheLight => true;
        public override bool Confuse => true;
        public override string Description => "A huge dragon emanating from the elemental plains, the ethereal dragon is a master of light and dark. Its form disappears from sight as it cloaks itself in unearthly shadows.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Ethereal dragon";
        public override int Hdice => 21;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 43;
        public override int Mexp => 11000;
        public override bool MoveBody => true;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 15;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Ethereal  ";
        public override string SplitName3 => "   dragon   ";
    }
}
