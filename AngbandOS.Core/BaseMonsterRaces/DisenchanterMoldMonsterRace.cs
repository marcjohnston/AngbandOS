using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DisenchanterMoldMonsterRace : Base2MonsterRace
    {
        public override char Character => 'm';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Disenchanter mold";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new UnBonusAttackEffect(), 1, 6),
        };
        public override bool AttrMulti => true;
        public override string Description => "It is a strange glowing growth on the dungeon floor.";
        public override bool DrainMana => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Disenchanter mold";
        public override int Hdice => 16;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 10;
        public override int Mexp => 40;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 2;
        public override bool ResistDisenchant => true;
        public override int Sleep => 70;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Disenchanter";
        public override string SplitName3 => "    mold    ";
        public override bool Stupid => true;
    }
}
