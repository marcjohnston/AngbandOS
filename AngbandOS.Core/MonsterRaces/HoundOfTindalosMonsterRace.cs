using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HoundOfTindalosMonsterRace : MonsterRace
    {
        protected HoundOfTindalosMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheNetherMonsterSpell(),
            new BreatheTimeMonsterSpell(),
            new BlinkMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'C';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Hound of Tindalos";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new LoseWisAttackEffect(), 2, 12),
            new MonsterAttack(new BiteAttackType(), new LoseWisAttackEffect(), 2, 12),
            new MonsterAttack(new BiteAttackType(), new LoseWisAttackEffect(), 2, 12),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 3, 3)
        };
        public override bool Cthuloid => true;
        public override string Description => "'They are lean and athirst!'";
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Hound of Tindalos";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 15;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 54;
        public override int Mexp => 8000;
        public override int NoticeRange => 30;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool ResistNether => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "   Hound    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "  Tindalos  ";
    }
}
