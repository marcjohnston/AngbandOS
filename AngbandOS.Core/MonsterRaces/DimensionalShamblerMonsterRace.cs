using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DimensionalShamblerMonsterRace : MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Dimensional shambler";

        public override int ArmourClass => 68;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool Confuse => true;
        public override bool Cthuloid => true;
        public override string Description => "A shabby humanoid with a wrinkled skin. It seems to shift in and out of existance as you watch.";
        public override bool Drop_2D2 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Dimensional shambler";
        public override bool Good => true;
        public override bool Haste => true;
        public override int Hdice => 40;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 29;
        public override int Mexp => 400;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 6;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 255;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Dimensional ";
        public override string SplitName3 => "  shambler  ";
        public override bool TakeItem => true;
        public override bool TeleportSelf => true;
    }
}