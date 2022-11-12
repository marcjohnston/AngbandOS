using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class EogGolemMonsterRace : MonsterRace
    {
        public override char Character => 'g';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Eog golem";

        public override int ArmourClass => 125;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 8, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 8, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 6, 6)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a massive deep brown statue, striding towards you with an all-too-familiar purpose. Your magic surprisingly feels much less powerful now.";
        public override bool Drop_2D2 => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Eog golem";
        public override int Hdice => 100;
        public override int Hside => 20;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 35;
        public override int Mexp => 1200;
        public override bool Nonliving => true;
        public override int NoticeRange => 12;
        public override bool OnlyDropGold => true;
        public override int Rarity => 4;
        public override bool Reflecting => true;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Eog     ";
        public override string SplitName3 => "   golem    ";
    }
}
