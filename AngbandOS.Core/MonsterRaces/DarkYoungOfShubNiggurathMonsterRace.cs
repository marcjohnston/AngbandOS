using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DarkYoungOfShubNiggurathMonsterRace : MonsterRace
    {
        protected DarkYoungOfShubNiggurathMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseSeriousWoundsMonsterSpell(),
            new HealMonsterSpell(),
            new SummonCthuloidMonsterSpell());
        public override char Character => 'A';
        public override Colour Colour => Colour.Green;
        public override string Name => "Dark young of Shub-Niggurath";

        public override int ArmourClass => 75;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 5, 6),
            new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 5, 6),
            new MonsterAttack(new BiteAttackType(), new LoseStrAttackEffect(), 1, 6),
            new MonsterAttack(new BiteAttackType(), new LoseStrAttackEffect(), 1, 6)
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "A black, ropy, slimy jelly tree-thing; an enormous writhing mass.";
        public override bool Drop_1D2 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Dark young of Shub-Niggurath";
        public override int Hdice => 12;
        public override int Hside => 100;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 43;
        public override int Mexp => 5000;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "  young of  ";
        public override string SplitName3 => "Shub-Niggura";
    }
}
