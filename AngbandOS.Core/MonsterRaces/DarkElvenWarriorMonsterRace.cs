using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DarkElvenWarriorMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new MagicMissileMonsterSpell());
        public override char Character => 'h';
        public override Colour Colour => Colour.Black;
        public override string Name => "Dark elven warrior";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A dark elven figure in armour and ready with his sword.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Dark elven warrior";
        public override int Hdice => 10;
        public override int Hside => 11;
        public override bool HurtByLight => true;
        public override int LevelFound => 10;
        public override bool Male => true;
        public override int Mexp => 50;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "  warrior   ";
    }
}
