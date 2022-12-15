using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AirHoundMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreathePoisonMonsterSpell());
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Air hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override string Description => "Swirling vapours surround this beast as it floats towards you, seemingly walking on air. Noxious gases sting your throat.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Air hound";
        public override bool Friends => true;
        public override int Hdice => 15;
        public override int Hside => 8;
        public override bool ImmunePoison => true;
        public override int LevelFound => 20;
        public override int Mexp => 200;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Air     ";
        public override string SplitName3 => "   hound    ";
    }
}
