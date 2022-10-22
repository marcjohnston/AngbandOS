using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SilentWatcherMonsterRace : Base2MonsterRace
    {
        public override char Character => 'g';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Silent watcher";

        public override int ArmourClass => 80;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new TerrifyAttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new ParalyzeAttackEffect();
        public override AttackType Attack2Type => AttackType.Gaze;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new LoseStrAttackEffect();
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override string Description => "A figure carved from stone, with three vulture faces. Their eyes glow a malevolent light...";
        public override bool DrainMana => true;
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Silent watcher";
        public override int Hdice => 80;
        public override bool Hold => true;
        public override int Hside => 20;
        public override bool HurtByLight => true;
        public override bool HurtByRock => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 25;
        public override int Mexp => 590;
        public override bool MindBlast => true;
        public override bool NeverMove => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 42;
        public override int Rarity => 5;
        public override bool ResistTeleport => true;
        public override bool Shriek => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Silent   ";
        public override string SplitName3 => "  watcher   ";
        public override bool SummonMonster => true;
        public override bool SummonMonsters => true;
    }
}
