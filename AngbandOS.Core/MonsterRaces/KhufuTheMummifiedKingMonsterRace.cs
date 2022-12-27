using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class KhufuTheMummifiedKingMonsterRace : MonsterRace
    {
        protected KhufuTheMummifiedKingMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseCriticalWoundsMonsterSpell(),
            new ScareMonsterSpell(),
            new SlowMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new DarknessMonsterSpell(),
            new SummonKinMonsterSpell(),
            new SummonUndeadMonsterSpell());
        public override char Character => 'z';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Khufu the mummified King";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new GazeAttackType(), new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(new HitAttackType(), new PoisonAttackEffect(), 6, 6),
            new MonsterAttack(new ClawAttackType(), new LoseConAttackEffect(), 0, 0),
            new MonsterAttack(new ClawAttackType(), new LoseConAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "He is out to have a revenge on you who have desecrated his tomb.";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Khufu the mummified King";
        public override int Hdice => 85;
        public override int Hside => 11;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override int LevelFound => 26;
        public override bool Male => true;
        public override int Mexp => 500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => " Khufu the  ";
        public override string SplitName2 => " mummified  ";
        public override string SplitName3 => "    King    ";
        public override bool Undead => true;
        public override bool Unique => true;
    }
}
