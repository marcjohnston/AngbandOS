using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class SilentWatcherMonsterRace : MonsterRace
    {
        public override char Character => 'g';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Silent watcher";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new LoseStrAttackEffect(), 0, 0),
        };
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
        public override int LevelFound => 25;
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
