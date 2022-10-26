using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class QlzqqlzuupTheLordOfFleshMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Q';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Qlzqqlzuup, the Lord of Flesh";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override bool AttrMulti => true;
        public override string Description => "This disgusting creature squeals and snorts as it writhes on the floor. It pulsates with evil. Its intent is to overwhelm you with monster after monster, until it can greedily dine on your remains.";
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Qlzqqlzuup, the Lord of Flesh";
        public override int Hdice => 50;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 78;
        public override int Mexp => 20000;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Qlzqqlzuup ";
        public override bool SummonAnt => true;
        public override bool SummonCthuloid => true;
        public override bool SummonDemon => true;
        public override bool SummonDragon => true;
        public override bool SummonGreatOldOne => true;
        public override bool SummonHiDragon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonHound => true;
        public override bool SummonHydra => true;
        public override bool SummonKin => true;
        public override bool SummonMonster => true;
        public override bool SummonMonsters => true;
        public override bool SummonSpider => true;
        public override bool SummonUndead => true;
        public override bool SummonUnique => true;
        public override bool Unique => true;
    }
}
