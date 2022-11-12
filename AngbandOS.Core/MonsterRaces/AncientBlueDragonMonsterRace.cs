using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AncientBlueDragonMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Ancient blue dragon";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 8),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 8),
            new MonsterAttack(AttackType.Bite, new EatGoldAttackEffect(), 5, 8),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheLightning => true;
        public override bool Confuse => true;
        public override string Description => "A huge draconic form. Lightning crackles along its length.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Ancient blue dragon";
        public override int Hdice => 70;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 1500;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 80;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Ancient   ";
        public override string SplitName2 => "    blue    ";
        public override string SplitName3 => "   dragon   ";
    }
}
