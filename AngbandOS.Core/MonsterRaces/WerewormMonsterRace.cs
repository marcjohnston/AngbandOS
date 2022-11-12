using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WerewormMonsterRace : MonsterRace
    {
        public override char Character => 'w';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Wereworm";

        public override bool Animal => true;
        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new Exp20AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Crawl, new AcidAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 6)
        };
        public override bool BashDoor => true;
        public override string Description => "A huge wormlike shape dripping acid, twisted by evil sorcery into a foul monster that breeds on death.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Wereworm";
        public override int Hdice => 100;
        public override int Hside => 11;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 25;
        public override int Mexp => 300;
        public override int NoticeRange => 15;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Wereworm  ";
    }
}
