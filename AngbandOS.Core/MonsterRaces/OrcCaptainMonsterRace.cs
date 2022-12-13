using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class OrcCaptainMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new Arrow1D6MonsterSpell());
        public override char Character => 'o';
        public override Colour Colour => Colour.Green;
        public override string Name => "Orc captain";

        public override int ArmourClass => 59;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "An armoured orc with an air of authority.";
        public override bool Drop90 => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Orc captain";
        public override int Hdice => 20;
        public override int Hside => 10;
        public override int LevelFound => 16;
        public override bool Male => true;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Orc     ";
        public override string SplitName3 => "  captain   ";
    }
}
