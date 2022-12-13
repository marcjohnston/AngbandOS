using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BlackNagaMonsterRace : MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.Black;
        public override string Name => "Black naga";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A large black serpent's body with a female torso.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Black naga";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override int LevelFound => 3;
        public override int Mexp => 20;
        public override int NoticeRange => 16;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 120;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "    naga    ";
    }
}
