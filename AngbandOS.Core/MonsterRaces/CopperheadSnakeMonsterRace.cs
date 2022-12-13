using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CopperheadSnakeMonsterRace : MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Copperhead snake";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 2, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It has a copper head and sharp venomous fangs.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Copperhead snake";
        public override int Hdice => 4;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override int LevelFound => 5;
        public override int Mexp => 15;
        public override int NoticeRange => 6;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 1;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Copperhead ";
        public override string SplitName3 => "   snake    ";
    }
}
