using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BaronOfHellMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new PlasmaBoltMonsterSpell());
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Baron of hell";

        public override int ArmourClass => 130;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 11, 2),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 11, 2),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 11, 2),
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "A minor demon lord with a goat's head, tough to kill.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Baron of hell";
        public override int Hdice => 150;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override bool Male => true;
        public override int Mexp => 900;
        public override bool Nonliving => true;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Baron    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "    hell    ";
    }
}
