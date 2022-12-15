using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AntiPaladinMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new HoldMonsterSpell(),
            new ScareMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new DarknessMonsterSpell(),
            new ForgetMonsterSpell(),
            new HasteMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Anti-paladin";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "An embodiment of all the cardinal vices, he beholds you scornfully.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Anti-paladin";
        public override int Hdice => 30;
        public override int Hside => 20;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 33;
        public override bool Male => true;
        public override int Mexp => 450;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Anti-paladin";
        public override bool TakeItem => true;
    }
}
