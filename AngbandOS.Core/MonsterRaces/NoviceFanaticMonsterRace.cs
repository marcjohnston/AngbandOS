using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NoviceFanaticMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseLightWoundsMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'p';
        public override string Name => "Novice fanatic";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 7),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 7),
        };
        public override bool BashDoor => true;
        public override string Description => "He thinks you are an agent of the devil. ";
        public override bool Drop60 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Novice fanatic";
        public override bool Friends => true;
        public override bool Good => true;
        public override int Hdice => 6;
        public override int Hside => 8;
        public override int LevelFound => 8;
        public override bool Male => true;
        public override int Mexp => 20;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Novice   ";
        public override string SplitName3 => "  fanatic   ";
    }
}
