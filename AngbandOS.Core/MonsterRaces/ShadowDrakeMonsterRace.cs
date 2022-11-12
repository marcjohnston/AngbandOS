using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ShadowDrakeMonsterRace : MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Black;
        public override string Name => "Shadow drake";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "It is a dragon-like form wrapped in shadow. Glowing red eyes shine out in the dark.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Shadow drake";
        public override bool Haste => true;
        public override int Hdice => 20;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool Invisible => true;
        public override int LevelFound => 30;
        public override int Mexp => 700;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Shadow   ";
        public override string SplitName3 => "   drake    ";
        public override bool TakeItem => true;
    }
}
