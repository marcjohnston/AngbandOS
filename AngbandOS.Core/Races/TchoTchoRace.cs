// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class TchoTchoRace : Race
{
    private TchoTchoRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Tcho-Tcho";
    public override int[] AbilityBonus => new int[] { 3, -2, -1, 1, 2, -2 };
    public override int BaseDisarmBonus => -2;
    public override int BaseDeviceBonus => -10;
    public override int BaseSaveBonus => 2;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => 1;
    public override int BaseSearchFrequency => 7;
    public override int BaseMeleeAttackBonus => 12;
    public override int BaseRangedAttackBonus => 10;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 120;
    public override int BaseAge => 14;
    public override int AgeRange => 8;
    public override int MaleBaseHeight => 82;
    public override int MaleHeightRange => 5;
    public override int MaleBaseWeight => 200;
    public override int MaleWeightRange => 20;
    public override int FemaleBaseHeight => 78;
    public override int FemaleHeightRange => 6;
    public override int FemaleBaseWeight => 190;
    public override int FemaleWeightRange => 15;
    public override int Infravision => 0;
    public override uint Choice => 0xC89D;
    public override string Description => "Tcho-Tchos are hairless cannibalistic near-humans who dwell\nin isolated parts of the world away from more civilised\nplaces where their dark rituals and sacrifices go unseen.\nTcho-Tchos are immune to fear, and can also learn to create\nThe Yellow Sign (at lvl 35).";

    /// <summary>
    /// Tcho-Tcho 138->139->140->141->142->End 
    /// </summary>
    public override int Chart => 138;

    public override string RacialPowersDescription(int lvl) => lvl < 8 ? "berserk            (racial, unusable until level 8)" : "berserk            (racial, cost 10, WIS based)";
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.ResFear = true;
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new CthuloidSyllables());
    public override string[]? SelfKnowledge(int level)
    {
        if (level > 7)
        {
            return new string[] { "You can enter berserk fury (cost 10)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        SaveGame.HasFearResistance = true;
    }

    public override void UseRacialPower()
    {
        // Tcho-Tcho can create The Yellow Sign
        if (SaveGame.CheckIfRacialPowerWorks(25, 35, Ability.Intelligence, 15))
        {
            SaveGame.MsgPrint("You carefully draw The Yellow Sign...");
            SaveGame.YellowSign();
        }
    }

    public override ItemFactory OutfitItemClass(ItemFactory itemClass)
    {
        if (itemClass is FearResistanceRingItemFactory)
        {
            return SaveGame.SingletonRepository.ItemFactories.Get<SustainStrengthRingItemFactory>();
        }
        return itemClass;
    }
}