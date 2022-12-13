using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LivingstoneMonsterRace : MonsterRace
    {
        public override char Character => '#';
        public override string Name => "Livingstone";

        public override int ArmourClass => 28;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 5),
        };
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A sentient section of wall.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Livingstone";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool HurtByRock => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 20;
        public override int Mexp => 56;
        public override bool Multiply => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 45;
        public override int Rarity => 4;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Livingstone ";
    }
}
