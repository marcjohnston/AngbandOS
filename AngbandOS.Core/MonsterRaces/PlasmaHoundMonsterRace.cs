using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class PlasmaHoundMonsterRace : MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Plasma hound";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override bool BreathePlasma => true;
        public override string Description => "The very air warps as pure elemental energy stalks towards you in the shape of a giant hound. Your hair stands on end and your palms itch as you sense trouble.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Plasma hound";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 51;
        public override int Mexp => 5000;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistPlasma => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Plasma   ";
        public override string SplitName3 => "   hound    ";
    }
}
