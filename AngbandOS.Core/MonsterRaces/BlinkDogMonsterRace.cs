using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BlinkDogMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlinkMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'C';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Blink dog";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A strange magical member of the canine race, its form seems to shimmer and fade in front of your very eyes.";
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Blink dog";
        public override bool Friends => true;
        public override int Hdice => 8;
        public override int Hside => 8;
        public override int LevelFound => 18;
        public override int Mexp => 50;
        public override int NoticeRange => 20;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Blink    ";
        public override string SplitName3 => "    dog     ";
    }
}
