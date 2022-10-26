using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MultiHuedHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Multi-hued hound";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 4, 4)
        };
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BreatheAcid => true;
        public override bool BreatheCold => true;
        public override bool BreatheFire => true;
        public override bool BreatheLightning => true;
        public override bool BreathePoison => true;
        public override string Description => "Shimmering in rainbow hues, this hound is beautiful and deadly. ";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Multi-hued hound";
        public override bool Friends => true;
        public override int Hdice => 30;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 33;
        public override int Mexp => 600;
        public override int NoticeRange => 25;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Multi-hued ";
        public override string SplitName3 => "   hound    ";
    }
}
