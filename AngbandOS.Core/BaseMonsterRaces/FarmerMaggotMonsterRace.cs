using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FarmerMaggotMonsterRace : Base2MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Farmer Maggot";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Moan, null, 0, 0),
            new MonsterAttack(AttackType.Moan, null, 0, 0),
        };
        public override bool BashDoor => true;
        public override string Description => "He's lost his dogs. He's had his mushrooms stolen. He's not a happy hobbit!";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Farmer Maggot";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override int Sleep => 3;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Farmer   ";
        public override string SplitName3 => "   Maggot   ";
        public override bool Unique => true;
    }
}
