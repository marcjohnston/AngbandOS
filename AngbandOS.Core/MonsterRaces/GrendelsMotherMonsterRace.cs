using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GrendelsMotherMonsterRace : MonsterRace
    {
        protected GrendelsMotherMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'O';
        public override Colour Colour => Colour.Green;
        public override string Name => "Grendel's mother";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 8, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 8, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 8, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "She taught her son everything he knows.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grendel's mother";
        public override bool Giant => true;
        public override int Hdice => 25;
        public override int Hside => 100;
        public override bool ImmunePoison => true;
        public override int LevelFound => 28;
        public override int Mexp => 1500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Grendel's  ";
        public override string SplitName3 => "   mother   ";
        public override bool Unique => true;
    }
}
