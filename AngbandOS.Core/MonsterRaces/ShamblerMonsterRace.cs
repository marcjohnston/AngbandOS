using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ShamblerMonsterRace : MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Shambler";

        public override int ArmourClass => 150;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 12),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 8, 12)
        };
        public override bool BashDoor => true;
        public override bool BreatheLightning => true;
        public override string Description => "This elemental creature is power incarnate; it looks like a huge polar bear with a huge gaping maw instead of a head.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Shambler";
        public override int Hdice => 50;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 67;
        public override int Mexp => 22500;
        public override bool MoveBody => true;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 50;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Shambler  ";
    }
}