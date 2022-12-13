using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class YoungBlueDragonMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheLightningMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'd';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Young blue dragon";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It has a form that legends are made of. Its still-tender scales are a deep blue in hue. Sparks crackle along its length.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Young blue dragon";
        public override int Hdice => 27;
        public override int Hside => 10;
        public override bool ImmuneLightning => true;
        public override int LevelFound => 29;
        public override int Mexp => 300;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 70;
        public override int Speed => 110;
        public override string SplitName1 => "   Young    ";
        public override string SplitName2 => "    blue    ";
        public override string SplitName3 => "   dragon   ";
    }
}
