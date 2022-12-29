using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SmeagolMonsterRace : MonsterRace
    {
        protected SmeagolMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'h';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Smeagol";

        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new TouchAttackType(), new EatGoldAttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override string Description => "He's been sneaking, and he wants his 'precious.'";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Smeagol";
        public override int Hdice => 10;
        public override int Hside => 20;
        public override bool Invisible => true;
        public override int LevelFound => 3;
        public override bool Male => true;
        public override int Mexp => 16;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 5;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Smeagol   ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}
