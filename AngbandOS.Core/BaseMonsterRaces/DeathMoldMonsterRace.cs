using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DeathMoldMonsterRace : Base2MonsterRace
    {
        public override char Character => 'm';
        public override Colour Colour => Colour.Black;
        public override string Name => "Death mold";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 7, 7),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 7, 7),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 7, 7),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 5, 5)
        };
        public override string Description => "It is the epitome of all that is evil, in a mold. Its lifeless form draws power from sucking the souls of those that approach it, a nimbus of pure evil surrounds it. Luckily for you, it can't move.";
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Death mold";
        public override int Hdice => 100;
        public override int Hside => 20;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 47;
        public override int Mexp => 1000;
        public override bool NeverMove => true;
        public override int NoticeRange => 200;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 140;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Death    ";
        public override string SplitName3 => "    mold    ";
    }
}
