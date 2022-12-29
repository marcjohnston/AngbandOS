using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TheIckyQueenMonsterRace : MonsterRace
    {
        protected TheIckyQueenMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'i';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "The Icky Queen";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrawlAttackType(), new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(new CrawlAttackType(), new EatFoodAttackEffect(), 3, 4),
            new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 3, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5)
        };
        public override bool BashDoor => true;
        public override string Description => "And you thought her offspring were icky!";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "The Icky Queen";
        public override int Hdice => 40;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override int LevelFound => 20;
        public override int Mexp => 400;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 5;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "    Icky    ";
        public override string SplitName3 => "   Queen    ";
        public override bool TakeItem => true;
        public override bool Unique => true;
        public override bool WeirdMind => true;
    }
}
