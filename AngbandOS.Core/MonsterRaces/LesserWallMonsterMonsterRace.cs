using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LesserWallMonsterMonsterRace : MonsterRace
    {
        public override char Character => '#';
        public override string Name => "Lesser wall monster";

        public override int ArmourClass => 75;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A sentient, moving section of wall.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Lesser wall monster";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool HurtByRock => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int LevelFound => 28;
        public override int Mexp => 600;
        public override bool Multiply => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Lesser   ";
        public override string SplitName2 => "    wall    ";
        public override string SplitName3 => "  monster   ";
    }
}
