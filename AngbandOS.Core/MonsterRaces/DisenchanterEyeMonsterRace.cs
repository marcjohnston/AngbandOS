using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DisenchanterEyeMonsterRace : MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Disenchanter eye";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new UnBonusAttackEffect(), 0, 0),
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override string Description => "A disembodied eye, crackling with magic.";
        public override bool DrainMana => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Disenchanter eye";
        public override int Hdice => 7;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override int LevelFound => 5;
        public override int Mexp => 20;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 2;
        public override bool ResistDisenchant => true;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Disenchanter";
        public override string SplitName3 => "    eye     ";
    }
}