using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GnomeMageMonsterRace : MonsterRace
    {
        protected GnomeMageMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ColdBoltMonsterSpell(),
            new BlinkMonsterSpell(),
            new DarknessMonsterSpell(),
            new SummonMonsterMonsterSpell());
        public override char Character => 'h';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Gnome mage";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "A mage of short stature.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Gnome mage";
        public override bool Friends => true;
        public override int Hdice => 7;
        public override int Hside => 8;
        public override int LevelFound => 15;
        public override bool Male => true;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Gnome    ";
        public override string SplitName3 => "    mage    ";
    }
}
