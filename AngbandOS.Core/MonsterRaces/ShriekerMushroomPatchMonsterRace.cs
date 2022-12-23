using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ShriekerMushroomPatchMonsterRace : MonsterRace
    {
        protected ShriekerMushroomPatchMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ShriekMonsterSpell());
        public override char Character => ',';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Shrieker mushroom patch";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override string Description => "Yum! These look quite tasty.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Shrieker mushroom patch";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 2;
        public override int Mexp => 1;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 4;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "  Shrieker  ";
        public override string SplitName2 => "  mushroom  ";
        public override string SplitName3 => "   patch    ";
        public override bool Stupid => true;
    }
}
