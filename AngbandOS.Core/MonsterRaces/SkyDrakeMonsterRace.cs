using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SkyDrakeMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Sky Drake";

        public override int ArmourClass => 200;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Bite, new ElectricityAttackEffect(), 9, 15)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheGravity => true;
        public override bool BreatheLight => true;
        public override bool BreatheLightning => true;
        public override string Description => "The mightiest elemental dragon of air, it can destroy you with ease.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Sky Drake";
        public override bool Good => true;
        public override int Hdice => 60;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 69;
        public override bool LightningAura => true;
        public override int Mexp => 31000;
        public override bool MoveBody => true;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 255;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Sky     ";
        public override string SplitName3 => "   Drake    ";
        public override bool SummonDragon => true;
        public override bool SummonHiDragon => true;
    }
}
