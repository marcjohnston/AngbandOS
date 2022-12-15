using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RadiationEyeMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new DrainManaMonsterSpell());
        public override char Character => 'e';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Radiation eye";

        public override int ArmourClass => 6;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new LoseStrAttackEffect(), 1, 6),
        };
        public override string Description => "A disembodied eye, crackling with energy.";
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Radiation eye";
        public override int Hdice => 3;
        public override int Hside => 6;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override int LevelFound => 3;
        public override int Mexp => 6;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Radiation  ";
        public override string SplitName3 => "    eye     ";
    }
}
