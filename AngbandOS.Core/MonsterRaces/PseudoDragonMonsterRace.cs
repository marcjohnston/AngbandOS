using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class PseudoDragonMonsterRace : MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Pseudo dragon";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override bool BreatheDark => true;
        public override bool BreatheLight => true;
        public override bool Confuse => true;
        public override string Description => "A small relative of the dragon that inhabits dark caves.";
        public override bool Dragon => true;
        public override bool Drop60 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Pseudo dragon";
        public override int Hdice => 20;
        public override int Hside => 10;
        public override int LevelFound => 10;
        public override int Mexp => 150;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Pseudo   ";
        public override string SplitName3 => "   dragon   ";
    }
}