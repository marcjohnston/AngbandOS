using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreenNagaMonsterRace : MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.Green;
        public override string Name => "Green naga";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Spit, new AcidAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A large green serpent with a female's torso. Her green skin glistens with acid.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green naga";
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 5;
        public override int Mexp => 30;
        public override int NoticeRange => 18;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 120;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Green    ";
        public override string SplitName3 => "    naga    ";
        public override bool TakeItem => true;
    }
}
