using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class EnergyHoundMonsterRace : MonsterRace
    {
        protected EnergyHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheLightningMonsterSpell());
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Energy hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new ElectricityAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new ElectricityAttackEffect(), 1, 3),
        };
        public override bool BashDoor => true;
        public override string Description => "Saint Elmo's Fire forms a ghostly halo around this hound, and sparks sting your fingers as energy builds up in the air around you.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Energy hound";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 6;
        public override bool ImmuneLightning => true;
        public override int LevelFound => 18;
        public override int Mexp => 70;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Energy   ";
        public override string SplitName3 => "   hound    ";
    }
}
