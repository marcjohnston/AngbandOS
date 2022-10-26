using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GnomeMageMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Gnome mage";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool ColdBolt => true;
        public override bool Darkness => true;
        public override string Description => "A mage of short stature.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Gnome mage";
        public override bool Friends => true;
        public override int Hdice => 7;
        public override int Hside => 8;
        public override int Level => 15;
        public override bool Male => true;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Gnome    ";
        public override string SplitName3 => "    mage    ";
        public override bool SummonMonster => true;
    }
}
