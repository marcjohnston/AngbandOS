using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RedNagaMonsterRace : MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Red naga";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Bite, new LoseStrAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "A large red snake with a woman's torso.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Red naga";
        public override int Hdice => 11;
        public override int Hside => 8;
        public override int LevelFound => 7;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 120;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Red     ";
        public override string SplitName3 => "    naga    ";
        public override bool TakeItem => true;
    }
}
