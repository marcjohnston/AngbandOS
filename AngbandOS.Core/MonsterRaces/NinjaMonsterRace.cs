using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NinjaMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Black;
        public override string Name => "Ninja";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new LoseConAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "A humanoid clothed in black who moves with blinding speed.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Ninja";
        public override int Hdice => 13;
        public override int Hside => 12;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 32;
        public override bool Male => true;
        public override int Mexp => 300;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Ninja    ";
    }
}
