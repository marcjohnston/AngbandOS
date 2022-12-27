using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NoviceCultistMonsterRace : MonsterRace
    {
        protected NoviceCultistMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseLightWoundsMonsterSpell(),
            new ScareMonsterSpell(),
            new HealMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Novice cultist";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "He is tripping over his fetishes.";
        public override bool Drop60 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Novice cultist";
        public override int Hdice => 7;
        public override int Hside => 4;
        public override int LevelFound => 2;
        public override bool Male => true;
        public override int Mexp => 7;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Novice   ";
        public override string SplitName3 => "  cultist   ";
    }
}
