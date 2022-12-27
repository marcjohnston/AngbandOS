using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ScrawnyCatMonsterRace : MonsterRace
    {
        protected ScrawnyCatMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'f';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Scrawny cat";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 1),
        };
        public override string Description => "A skinny little furball with sharp claws and a menacing look.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Scrawny cat";
        public override int Hdice => 1;
        public override int Hside => 2;
        public override int LevelFound => 0;
        public override int Mexp => 0;
        public override int NoticeRange => 30;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Scrawny   ";
        public override string SplitName3 => "    cat     ";
    }
}
