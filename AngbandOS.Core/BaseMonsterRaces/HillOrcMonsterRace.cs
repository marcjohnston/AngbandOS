using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class HillOrcMonsterRace : Base2MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Hill orc";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
        };
        public override bool BashDoor => true;
        public override string Description => "He is a hardy well-weathered survivor.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hill orc";
        public override bool Friends => true;
        public override int Hdice => 13;
        public override int Hside => 9;
        public override bool HurtByLight => true;
        public override int Level => 8;
        public override bool Male => true;
        public override int Mexp => 25;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Hill    ";
        public override string SplitName3 => "    orc     ";
    }
}
