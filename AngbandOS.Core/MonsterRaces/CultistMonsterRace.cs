using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CultistMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseSeriousWoundsMonsterSpell(),
            new ScareMonsterSpell(),
            new HealMonsterSpell(),
            new SummonMonsterMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.Turquoise;
        public override string Name => "Cultist";

        public override int ArmourClass => 22;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 3),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 3),
        };
        public override bool BashDoor => true;
        public override string Description => "A robed humanoid dedicated to his outer god.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Cultist";
        public override bool Good => true;
        public override int Hdice => 12;
        public override int Hside => 8;
        public override int LevelFound => 12;
        public override bool Male => true;
        public override int Mexp => 36;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Cultist   ";
    }
}
