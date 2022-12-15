using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class QuylthulgMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlinkMonsterSpell(),
            new SummonMonsterMonsterSpell());
        public override char Character => 'Q';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Quylthulg";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override string Description => "It is a strange pulsing mound of flesh.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Quylthulg";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 20;
        public override int Mexp => 250;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 10;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Quylthulg  ";
    }
}
