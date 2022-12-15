using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GuardianNagaMonsterRace : MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Guardian naga";

        public override int ArmourClass => 65;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A giant snake-like figure with a woman's torso.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Guardian naga";
        public override int Hdice => 24;
        public override int Hside => 11;
        public override int LevelFound => 15;
        public override int Mexp => 80;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 120;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Guardian  ";
        public override string SplitName3 => "    naga    ";
    }
}
