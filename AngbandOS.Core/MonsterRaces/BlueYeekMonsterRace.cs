using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BlueYeekMonsterRace : MonsterRace
    {
        public override char Character => 'y';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Blue yeek";

        public override bool Animal => true;
        public override int ArmourClass => 14;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "A small humanoid figure.";
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Blue yeek";
        public override int Hdice => 2;
        public override int Hside => 6;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 2;
        public override int Mexp => 4;
        public override int NoticeRange => 18;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Blue    ";
        public override string SplitName3 => "    yeek    ";
    }
}
