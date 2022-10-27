using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DarkElvenCultistMonsterRace : MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Turquoise;
        public override string Name => "Dark elven cultist";

        public override int ArmourClass => 75;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 7),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 7),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
        };
        public override bool BashDoor => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A powerful dark elf, with mighty nature-controlling enchantments.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Dark elven cultist";
        public override int Hdice => 20;
        public override bool Heal => true;
        public override int Hside => 20;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 25;
        public override bool MagicMissile => true;
        public override int Mexp => 500;
        public override int NoticeRange => 15;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "  cultist   ";
        public override bool SummonMonster => true;
        public override bool SummonSpider => true;
    }
}
