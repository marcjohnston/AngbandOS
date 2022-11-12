using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SnagaMonsterRace : MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Snaga";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "He is one of the many weaker 'slave' orcs, often mistakenly known as a goblin.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Snaga";
        public override bool Friends => true;
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override int LevelFound => 6;
        public override bool Male => true;
        public override int Mexp => 15;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Snaga    ";
    }
}
