using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DoomDrakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Doom drake";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "Doom drakes are trained firedrakes, always moving in pairs, looking for a battle.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Doom drake";
        public override bool Friends => true;
        public override int Hdice => 40;
        public override int Hside => 11;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 34;
        public override int Mexp => 450;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Doom    ";
        public override string SplitName3 => "   drake    ";
    }
}
