using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MithrilGolemMonsterRace : MonsterRace
    {
        protected MithrilGolemMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'g';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Mithril golem";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a massive statue of purest mithril. It looks expensive!";
        public override bool Drop_2D2 => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Mithril golem";
        public override int Hdice => 80;
        public override int Hside => 15;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 30;
        public override int Mexp => 500;
        public override bool Nonliving => true;
        public override int NoticeRange => 12;
        public override bool OnlyDropGold => true;
        public override int Rarity => 4;
        public override bool Reflecting => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Mithril   ";
        public override string SplitName3 => "   golem    ";
    }
}
