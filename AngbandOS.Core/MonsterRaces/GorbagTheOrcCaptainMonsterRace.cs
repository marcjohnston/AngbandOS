using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GorbagTheOrcCaptainMonsterRace : MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Gorbag, the Orc Captain";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5)
        };
        public override bool BashDoor => true;
        public override string Description => "A gruesomely ugly but cunning orc, his eyes regard you with hatred. His powerful arms flex menacingly as he advances.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Gorbag, the Orc Captain";
        public override int Hdice => 40;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int LevelFound => 18;
        public override bool Male => true;
        public override int Mexp => 400;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Gorbag   ";
        public override bool Unique => true;
    }
}