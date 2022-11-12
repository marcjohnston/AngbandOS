using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BabyBlueDragonMonsterRace : MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Baby blue dragon";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override bool BreatheLightning => true;
        public override string Description => "This hatchling dragon is still soft, its eyes unaccustomed to light and its scales a pale blue.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Baby blue dragon";
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmuneLightning => true;
        public override int LevelFound => 9;
        public override int Mexp => 35;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 70;
        public override int Speed => 110;
        public override string SplitName1 => "    Baby    ";
        public override string SplitName2 => "    blue    ";
        public override string SplitName3 => "   dragon   ";
    }
}
