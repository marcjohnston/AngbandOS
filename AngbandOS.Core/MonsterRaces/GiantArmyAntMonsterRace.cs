using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantArmyAntMonsterRace : MonsterRace
    {
        public override char Character => 'a';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Giant army ant";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
        };
        public override bool BashDoor => true;
        public override string Description => "An armoured form moving with purpose. Powerful on its own, flee when hordes of them march.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant army ant";
        public override bool Friends => true;
        public override int Hdice => 19;
        public override int Hside => 6;
        public override bool KillBody => true;
        public override int LevelFound => 30;
        public override int Mexp => 90;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 40;
        public override int Speed => 120;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "    army    ";
        public override string SplitName3 => "    ant     ";
        public override bool WeirdMind => true;
    }
}
