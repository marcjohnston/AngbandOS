using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheUltimateDungeonCleanerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'g';
        public override Colour Colour => Colour.Black;
        public override string Name => "The Ultimate Dungeon Cleaner";

        public override int ArmourClass => 80;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Crush;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Crush;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Crush;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It looks like a huge spiked roller. It was designed to keep this dungeon clean, and you are the biggest spot of dirt in sight.";
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "The Ultimate Dungeon Cleaner";
        public override int Hdice => 70;
        public override int Hside => 12;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int Level => 28;
        public override int Mexp => 555;
        public override bool Nonliving => true;
        public override int NoticeRange => 10;
        public override int Rarity => 2;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 12;
        public override int Speed => 120;
        public override string SplitName1 => "The Ultimate";
        public override string SplitName2 => "  Dungeon   ";
        public override string SplitName3 => "  Cleaner   ";
        public override bool Unique => true;
    }
}
