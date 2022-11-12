using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RottingQuylthulgMonsterRace : MonsterRace
    {
        public override char Character => 'Q';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Rotting quylthulg";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override bool Blink => true;
        public override string Description => "It is a pulsing flesh mound that reeks of death and putrefaction.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Rotting quylthulg";
        public override int Hdice => 16;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 40;
        public override int Mexp => 1500;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Rotting   ";
        public override string SplitName3 => " quylthulg  ";
        public override bool SummonUndead => true;
        public override bool TeleportSelf => true;
    }
}
