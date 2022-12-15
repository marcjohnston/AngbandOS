using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MagicMushroomPatchMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ScareMonsterSpell(),
            new SlowMonsterSpell(),
            new BlinkMonsterSpell(),
            new DarknessMonsterSpell());
        public override char Character => ',';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Magic mushroom patch";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => null;
        public override string Description => "Yum! It looks quite tasty. It seems to glow with an unusual light.";
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Magic mushroom patch";
        public override bool Friends => true;
        public override int Hdice => 1;
        public override int Hside => 1;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 15;
        public override int Mexp => 10;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 40;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "   Magic    ";
        public override string SplitName2 => "  mushroom  ";
        public override string SplitName3 => "   patch    ";
        public override bool Stupid => true;
    }
}
