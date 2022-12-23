using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BaphometTheMinotaurLordMonsterRace : MonsterRace
    {
        protected BaphometTheMinotaurLordMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new Arrow7D6MonsterSpell(),
            new BreatheForceMonsterSpell(),
            new LightningBallMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new PlasmaBoltMonsterSpell(),
            new SlowMonsterSpell());
        public override char Character => 'H';
        public override Colour Colour => Colour.Red;
        public override string Name => "Baphomet, the Minotaur Lord";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Butt, new HurtAttackEffect(), 12, 13),
            new MonsterAttack(AttackType.Butt, new HurtAttackEffect(), 12, 13),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 10)
        };
        public override bool BashDoor => true;
        public override string Description => "A fearsome bull-headed demon, Baphomet swings a mighty axe as he curses all that defy him.";
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Baphomet, the Minotaur Lord";
        public override int Hdice => 35;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 51;
        public override bool Male => true;
        public override int Mexp => 18000;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override int Rarity => 4;
        public override int Sleep => 30;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Baphomet  ";
        public override bool Unique => true;
    }
}
