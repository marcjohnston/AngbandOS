using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class UglukTheUrukMonsterRace : MonsterRace
    {
        protected UglukTheUrukMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'o';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Ugluk, the Uruk";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5)
        };
        public override bool BashDoor => true;
        public override string Description => "Another of Morgoth's servants, this orc is strong and cunning. He is ugly and scarred from many power struggles.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Ugluk, the Uruk";
        public override int Hdice => 64;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int LevelFound => 20;
        public override bool Male => true;
        public override int Mexp => 550;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 4;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Ugluk    ";
        public override bool Unique => true;
    }
}
