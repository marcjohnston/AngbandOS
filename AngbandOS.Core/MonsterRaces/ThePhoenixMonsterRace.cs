using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ThePhoenixMonsterRace : MonsterRace
    {
        public override char Character => 'B';
        public override Colour Colour => Colour.Red;
        public override string Name => "The Phoenix";

        public override bool Animal => true;
        public override int ArmourClass => 130;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new FireAttackEffect(), 12, 6),
            new MonsterAttack(AttackType.Bite, new FireAttackEffect(), 12, 6),
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 9, 12),
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 9, 12)
        };
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override bool BreatheLight => true;
        public override bool BreathePlasma => true;
        public override string Description => "A massive glowing eagle bathed in flames. The searing heat chars your skin and melts your armour.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool FireAura => true;
        public override bool FireBall => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "The Phoenix";
        public override bool Good => true;
        public override int Hdice => 36;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 54;
        public override int Mexp => 40000;
        public override int NoticeRange => 60;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override int Rarity => 3;
        public override bool ResistPlasma => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => "  Phoenix   ";
        public override bool Unique => true;
    }
}
