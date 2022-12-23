using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FireSpiritMonsterRace : MonsterRace
    {
        protected FireSpiritMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Fire spirit";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A whirlwind of sentient flame.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Fire spirit";
        public override int Hdice => 10;
        public override int Hside => 9;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 18;
        public override int Mexp => 75;
        public override int NoticeRange => 16;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => "   spirit   ";
    }
}
