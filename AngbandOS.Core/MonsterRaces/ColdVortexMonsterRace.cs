using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ColdVortexMonsterRace : MonsterRace
    {
        public override char Character => 'v';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Cold vortex";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Engulf, new ColdAttackEffect(), 3, 3),
        };
        public override bool BashDoor => true;
        public override bool BreatheCold => true;
        public override string Description => "A twisting whirlpool of frost.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Cold vortex";
        public override int Hdice => 9;
        public override int Hside => 9;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 21;
        public override int Mexp => 100;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Cold    ";
        public override string SplitName3 => "   vortex   ";
    }
}