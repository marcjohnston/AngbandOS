using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class TheStormbringerMonsterRace : MonsterRace
    {
        public override char Character => '|';
        public override Colour Colour => Colour.Black;
        public override string Name => "The Stormbringer";

        public override int ArmourClass => 99;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Wail, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 8, 8),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 8, 8),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 8, 8)
        };
        public override bool BashDoor => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "The mightiest of hellblades, a black runesword which thirsts for your soul.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "The Stormbringer";
        public override int Hdice => 13;
        public override int Hside => 123;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 45;
        public override int Mexp => 13333;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override bool ResistNether => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => "Stormbringer";
        public override bool Unique => true;
    }
}
