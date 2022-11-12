using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AncientBronzeDragonMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Ancient bronze dragon";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 8),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 8),
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 5, 10),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheConfusion => true;
        public override bool Confuse => true;
        public override string Description => "A huge draconic form enveloped in a cascade of colour.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Ancient bronze dragon";
        public override int Hdice => 73;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 1700;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 200;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Ancient   ";
        public override string SplitName2 => "   bronze   ";
        public override string SplitName3 => "   dragon   ";
    }
}
