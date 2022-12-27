using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LagdufTheSnagaMonsterRace : MonsterRace
    {
        protected LagdufTheSnagaMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'o';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Lagduf, the Snaga";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 9),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 9)
        };
        public override bool BashDoor => true;
        public override string Description => "A captain of a regiment of weaker orcs, Lagduf keeps his troop in order with displays of excessive violence.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Lagduf, the Snaga";
        public override int Hdice => 19;
        public override int Hside => 10;
        public override int LevelFound => 8;
        public override bool Male => true;
        public override int Mexp => 80;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Lagduf   ";
        public override bool Unique => true;
    }
}
