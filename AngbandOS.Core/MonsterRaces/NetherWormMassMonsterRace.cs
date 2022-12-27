using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NetherWormMassMonsterRace : MonsterRace
    {
        protected NetherWormMassMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'w';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nether worm mass";

        public override bool Animal => true;
        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new TouchAttackType(), new Exp10AttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a disgusting mass of dark worms, eating each other, the floor, the air, you....";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Nether worm mass";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override int LevelFound => 12;
        public override int Mexp => 6;
        public override bool Multiply => true;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override int Sleep => 3;
        public override int Speed => 100;
        public override string SplitName1 => "   Nether   ";
        public override string SplitName2 => "    worm    ";
        public override string SplitName3 => "    mass    ";
        public override bool Stupid => true;
        public override bool WeirdMind => true;
    }
}
