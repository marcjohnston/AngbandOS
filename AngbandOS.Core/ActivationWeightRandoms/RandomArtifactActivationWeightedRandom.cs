// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ActivationWeightRandoms;

/// <summary>
/// Represents the <see cref="WeightedRandom"/> of <see cref="Activation"/> objects that is used when a random artifact is created.
/// </summary>
[Serializable]
internal class RandomArtifactActivationWeightedRandom : ActivationWeightedRandom
{
    private RandomArtifactActivationWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string, int)[] ActivationNamesAndWeights => new (string, int)[]
    {
        (nameof(SunlightDirectionalActivation), 100),
        (nameof(MagicMissile2d6Every2DirectionalActivation), 100),
        (nameof(StinkingCloud12Every1d4p4DirectionalActivation), 100),
        (nameof(LightningBolt4d8Every6p1d6DirectionalActivation), 100),
        (nameof(AcidBolt5d8Every5p1d5DirectionalActivation), 100),
        (nameof(FrostBolt6d8Every7p1d7DirectionalActivation), 100),
        (nameof(FireBolt9d8Every8p1d8DirectionalActivation), 100),
        (nameof(ConfuseMonster20Every15DirectionalActivation), 100),
        (nameof(SleepActivation), 100),
        (nameof(QuakeActivation), 100),
        (nameof(RemoveFearAndHeal30Every10Activation), 100),
        (nameof(Heal4d8AndWoundsEvery3p1d3Activation), 100),
        (nameof(RemoveFearAndPoisonEvery5Activation), 100),
        (nameof(Berserk50p1d50Every100p1d100Activation), 100),
        (nameof(LightActivation), 100),
        (nameof(MapLightActivation), 100),
        (nameof(DestroyDoorsEvery10Activation), 100),
        (nameof(StoneMudDirectionalActivation), 100),
        (nameof(Teleport100Every45Activation), 100),

        (nameof(BallOfCold48r2Every400DirectionalActivation), 85),
        (nameof(BallOfFire72r2Every400DirectionalActivation), 85),
        (nameof(DrainLife100Every100p1d100DirectionalActivation), 85),
        (nameof(TeleAwayDirectionalActivation), 85),
        (nameof(TemporaryEsp20p1d30Every200Activation), 85),
        (nameof(ResistAll40p1d40Activation), 85),
        (nameof(DetectionEvery55p1d55Activation), 85),
        (nameof(RecallActivation), 85),
        (nameof(SatiateActivation), 85),
        (nameof(RechargeActivation), 85),

        (nameof(Terror40xEvery3xp10Activation), 75),
        (nameof(ProtectionFromEvilActivation), 75),
        (nameof(IdentifyEvery10Activation), 75),

        (nameof(DrainLife120Every400DirectionalActivation), 66),
        (nameof(Vampire1DirectionalActivation), 66),
        (nameof(Arrows150Every90p1d90DirectionalActivation), 66),
        (nameof(FireBall120r3Every225p1d225DirectionalActivation), 66),
        (nameof(RestLifeActivation), 66),

        (nameof(BallOfCold100r2Every300DirectionalActivation), 50),
        (nameof(BallOfLightning100r3Every500DirectionalActivation), 50),
        (nameof(WhirlwindActivation), 50),
        (nameof(DrainLife100Every100p1d100DirectionalActivation), 50),
        (nameof(CharmAnimal1xEvery300DirectionalActivation), 50),

        (nameof(SummonAnimalActivation), 40),

        (nameof(DispelEvil5xEvery300p1d300Activation), 33),
        (nameof(ElementalBreath300r4Every500DirectionalActivation), 33),
        (nameof(DispelGood5xEvery300p1d300Activation), 33),
        (nameof(BanishEvilEvery250p1d250Activation), 33),
        (nameof(MassCarnageActivation), 33),
        (nameof(GenocideEvery500Activation), 33),
        (nameof(EnslaveUndead1xEvery333DirectionalActivation), 33),
        (nameof(CharmMonster1xEvery400DirectionalActivation), 33),
        (nameof(SummonPhantomActivation), 33),
        (nameof(RestAllActivation), 33),
        (nameof(RuneExploActivation), 33),

        (nameof(CallChaosEvery350Activation), 25),
        (nameof(ShardBallDirectionalActivation), 25),
        (nameof(CharmAnimalEvery500Activation), 25),
        (nameof(MassCharmEvery750Activation), 25),

        (nameof(SummonElementalActivation), 25),
        (nameof(Heal700Every25Activation), 25),
        (nameof(Speed20p1d20Every250Activation), 25),
        (nameof(IdentifyFullyEvery750Activation), 25),
        (nameof(RuneProtActivation), 25),

        (nameof(Heal1000Every888Activation), 10),
        (nameof(XtraSpeedActivation), 10),
        (nameof(ProbingDetectionAndFullIdEvery1000Activation), 10),
        (nameof(DimensionalGateEvery100Activation), 10),

        (nameof(SummonUndeadActivation), 5),
        (nameof(SummonDemonActivation), 5),
        (nameof(WraithActivation), 5),
        (nameof(InvulnActivation), 5),
        (nameof(AlchemyEvery500Activation), 5)
    };
}
