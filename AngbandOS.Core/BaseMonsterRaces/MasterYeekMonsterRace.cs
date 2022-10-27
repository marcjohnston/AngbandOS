using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MasterYeekMonsterRace : MonsterRace
    {
        public override char Character => 'y';
        public override Colour Colour => Colour.Green;
        public override string Name => "Master yeek";

        public override bool Animal => true;
        public override int ArmourClass => 24;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override string Description => "A small humanoid that radiates some power.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Master yeek";
        public override int Hdice => 12;
        public override int Hside => 9;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 12;
        public override int Mexp => 28;
        public override int NoticeRange => 18;
        public override bool OpenDoor => true;
        public override bool PoisonBall => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => "    yeek    ";
        public override bool SummonMonster => true;
        public override bool TeleportSelf => true;
    }
}
