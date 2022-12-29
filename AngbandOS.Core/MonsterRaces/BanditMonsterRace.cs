using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BanditMonsterRace : MonsterRace
    {
        protected BanditMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'p';
        public override Colour Colour => Colour.Black;
        public override string Name => "Bandit";

        public override int ArmourClass => 24;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 4),
            new MonsterAttack(new TouchAttackType(), new EatGoldAttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override string Description => "He is after your cash!";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Bandit";
        public override int Hdice => 8;
        public override int Hside => 8;
        public override int LevelFound => 8;
        public override bool Male => true;
        public override int Mexp => 26;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Bandit   ";
        public override bool TakeItem => true;
    }
}
