using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DraconicQuylthulgMonsterRace : MonsterRace
    {
        public override char Character => 'Q';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Draconic quylthulg";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override bool Blink => true;
        public override string Description => "It looks like it was once a dragon corpse, now deeply infected with magical bacteria that make it pulse in a foul and degrading way.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Draconic quylthulg";
        public override int Hdice => 72;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 55;
        public override int Mexp => 5500;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override int Rarity => 3;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Draconic  ";
        public override string SplitName3 => " quylthulg  ";
        public override bool SummonDragon => true;
        public override bool TeleportSelf => true;
    }
}