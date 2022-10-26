using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class HomonculousMonsterRace : Base2MonsterRace
    {
        public override char Character => 'u';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Homonculous";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new ParalyzeAttackEffect(), 1, 2),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "It is a small demonic spirit full of malevolence.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Homonculous";
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override int Level => 15;
        public override int Mexp => 40;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Homonculous ";
    }
}
