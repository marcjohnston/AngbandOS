using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ShadowHoundMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheDarkMonsterSpell());
        public override char Character => 'Z';
        public override Colour Colour => Colour.Black;
        public override string Name => "Shadow hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A hole in the air in the shape of a huge hound. No light falls upon its form.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Shadow hound";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 6;
        public override bool HurtByLight => true;
        public override int LevelFound => 15;
        public override int Mexp => 50;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Shadow   ";
        public override string SplitName3 => "   hound    ";
    }
}
