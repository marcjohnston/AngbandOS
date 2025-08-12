// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an item characteristics test.
/// </summary>
[Serializable]
internal abstract class ItemTest : IGetKey
{
    protected readonly Game Game;
    protected ItemTest(Game game)
    {
        Game = game;
    }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public void Bind() { }


    private bool TestBoolean(bool? testValue, bool actualValue)
    {
        if (testValue.HasValue) 
        {
            if (testValue.Value != actualValue)
            {
                return false;
            }
        }
        return true;
    }

    private bool TestNullObject<T>(bool? testValue, T? actualValue)
    {
        if (testValue.HasValue)
        {
            if (testValue.Value == true && actualValue == null)
            {
                return false;
            }
            if (testValue.Value == false && actualValue != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool Test(EffectivePropertySet effectivePropertySet)
    {
        if (!TestNullObject<Activation>(HasActivation, effectivePropertySet.Activation))
        {
            return false;
        }
        if (!TestBoolean(CanApplyBlessedArtifactBias, effectivePropertySet.CanApplyBlessedArtifactBias))
        {
            return false;
        }
        if (!TestBoolean(CanApplyArtifactBiasSlaying, effectivePropertySet.CanApplyArtifactBiasSlaying))
        {
            return false;
        }
        if (!TestBoolean(Aggravate, effectivePropertySet.Aggravate))
        {
            return false;
        }
        if (!TestBoolean(AntiTheft, effectivePropertySet.AntiTheft))
        {
            return false;
        }
        if (!TestNullObject<ArtifactBias>(ArtifactBias, effectivePropertySet.ArtifactBias))
        {
            return false;
        }
        if (!TestBoolean(Blessed, effectivePropertySet.Blessed))
        {
            return false;
        }
        if (!TestBoolean(BrandAcid, effectivePropertySet.BrandAcid))
        {
            return false;
        }
        if (!TestBoolean(BrandCold, effectivePropertySet.BrandCold))
        {
            return false;
        }
        if (!TestBoolean(BrandElec, effectivePropertySet.BrandElec))
        {
            return false;
        }
        if (!TestBoolean(BrandFire, effectivePropertySet.BrandFire))
        {
            return false;
        }
        if (!TestBoolean(BrandPois, effectivePropertySet.BrandPois))
        {
            return false;
        }
        if (!TestBoolean(Chaotic, effectivePropertySet.Chaotic))
        {
            return false;
        }
        if (!TestBoolean(IsCursed, effectivePropertySet.IsCursed))
        {
            return false;
        }
        if (!TestBoolean(DrainExp, effectivePropertySet.DrainExp))
        {
            return false;
        }
        if (!TestBoolean(DreadCurse, effectivePropertySet.DreadCurse))
        {
            return false;
        }
        if (!TestBoolean(EasyKnow, effectivePropertySet.EasyKnow))
        {
            return false;
        }
        if (!TestBoolean(Feather, effectivePropertySet.Feather))
        {
            return false;
        }
        if (!TestBoolean(FreeAct, effectivePropertySet.FreeAct))
        {
            return false;
        }
        if (!TestBoolean(HeavyCurse, effectivePropertySet.HeavyCurse))
        {
            return false;
        }
        if (!TestBoolean(HideType, effectivePropertySet.HideType))
        {
            return false;
        }
        if (!TestBoolean(HoldLife, effectivePropertySet.HoldLife))
        {
            return false;
        }
        if (!TestBoolean(IgnoreAcid, effectivePropertySet.IgnoreAcid))
        {
            return false;
        }
        if (!TestBoolean(IgnoreCold, effectivePropertySet.IgnoreCold))
        {
            return false;
        }
        if (!TestBoolean(IgnoreElec, effectivePropertySet.IgnoreElec))
        {
            return false;
        }
        if (!TestBoolean(IgnoreFire, effectivePropertySet.IgnoreFire))
        {
            return false;
        }
        if (!TestBoolean(ImAcid, effectivePropertySet.ImAcid))
        {
            return false;
        }
        if (!TestBoolean(ImCold, effectivePropertySet.ImCold))
        {
            return false;
        }
        if (!TestBoolean(ImElec, effectivePropertySet.ImElec))
        {
            return false;
        }
        if (!TestBoolean(ImFire, effectivePropertySet.ImFire))
        {
            return false;
        }
        if (!TestBoolean(Impact, effectivePropertySet.Impact))
        {
            return false;
        }
        if (!TestBoolean(NoMagic, effectivePropertySet.NoMagic))
        {
            return false;
        }
        if (!TestBoolean(NoTele, effectivePropertySet.NoTele))
        {
            return false;
        }
        if (!TestBoolean(PermaCurse, effectivePropertySet.PermaCurse))
        {
            return false;
        }
        if (!TestBoolean(Radius, effectivePropertySet.Radius > 0))
        {
            return false;
        }
        if (!TestBoolean(Reflect, effectivePropertySet.Reflect))
        {
            return false;
        }
        if (!TestBoolean(Regen, effectivePropertySet.Regen))
        {
            return false;
        }
        if (!TestBoolean(ResAcid, effectivePropertySet.ResAcid))
        {
            return false;
        }
        if (!TestBoolean(ResBlind, effectivePropertySet.ResBlind))
        {
            return false;
        }
        if (!TestBoolean(ResChaos, effectivePropertySet.ResChaos))
        {
            return false;
        }
        if (!TestBoolean(ResCold, effectivePropertySet.ResCold))
        {
            return false;
        }
        if (!TestBoolean(ResConf, effectivePropertySet.ResConf))
        {
            return false;
        }
        if (!TestBoolean(ResDark, effectivePropertySet.ResDark))
        {
            return false;
        }
        if (!TestBoolean(ResDisen, effectivePropertySet.ResDisen))
        {
            return false;
        }
        if (!TestBoolean(ResElec, effectivePropertySet.ResElec))
        {
            return false;
        }
        if (!TestBoolean(ResFear, effectivePropertySet.ResFear))
        {
            return false;
        }
        if (!TestBoolean(ResFire, effectivePropertySet.ResFire))
        {
            return false;
        }
        if (!TestBoolean(ResLight, effectivePropertySet.ResLight))
        {
            return false;
        }
        if (!TestBoolean(ResNether, effectivePropertySet.ResNether))
        {
            return false;
        }
        if (!TestBoolean(ResNexus, effectivePropertySet.ResNexus))
        {
            return false;
        }
        if (!TestBoolean(ResPois, effectivePropertySet.ResPois))
        {
            return false;
        }
        if (!TestBoolean(ResShards, effectivePropertySet.ResShards))
        {
            return false;
        }
        if (!TestBoolean(ResSound, effectivePropertySet.ResSound))
        {
            return false;
        }
        if (!TestBoolean(SeeInvis, effectivePropertySet.SeeInvis))
        {
            return false;
        }
        if (!TestBoolean(FactoryAllowsShElecricity, effectivePropertySet.CanProvideSheathOfElectricity))
        {
            return false;
        }
        if (!TestBoolean(ShElec, effectivePropertySet.ShElec))
        {
            return false;
        }
        if (!TestBoolean(FactoryAllowsShFire, effectivePropertySet.CanProvideSheathOfFire))
        {
            return false;
        }
        if (!TestBoolean(ShFire, effectivePropertySet.ShFire))
        {
            return false;
        }
        if (!TestBoolean(ShowMods, effectivePropertySet.ShowMods))
        {
            return false;
        }
        if (!TestBoolean(SlayAnimal, effectivePropertySet.SlayAnimal))
        {
            return false;
        }
        if (!TestBoolean(SlayDemon, effectivePropertySet.SlayDemon))
        {
            return false;
        }
        if (!TestBoolean(SlayDragon, effectivePropertySet.SlayDragon > 1))
        {
            return false;
        }
        if (!TestBoolean(SlayEvil, effectivePropertySet.SlayEvil))
        {
            return false;
        }
        if (!TestBoolean(SlayGiant, effectivePropertySet.SlayGiant))
        {
            return false;
        }
        if (!TestBoolean(SlayOrc, effectivePropertySet.SlayOrc))
        {
            return false;
        }
        if (!TestBoolean(SlayTroll, effectivePropertySet.SlayTroll))
        {
            return false;
        }
        if (!TestBoolean(SlayUndead, effectivePropertySet.SlayUndead))
        {
            return false;
        }
        if (!TestBoolean(SlowDigest, effectivePropertySet.SlowDigest))
        {
            return false;
        }
        if (!TestBoolean(SustCha, effectivePropertySet.SustCha))
        {
            return false;
        }
        if (!TestBoolean(SustCon, effectivePropertySet.SustCon))
        {
            return false;
        }
        if (!TestBoolean(SustDex, effectivePropertySet.SustDex))
        {
            return false;
        }
        if (!TestBoolean(SustInt, effectivePropertySet.SustInt))
        {
            return false;
        }
        if (!TestBoolean(SustStr, effectivePropertySet.SustStr))
        {
            return false;
        }
        if (!TestBoolean(SustWis, effectivePropertySet.SustWis))
        {
            return false;
        }
        if (!TestBoolean(Telepathy, effectivePropertySet.Telepathy))
        {
            return false;
        }
        if (!TestBoolean(Teleport, effectivePropertySet.Teleport))
        {
            return false;
        }
        if (!TestBoolean(TreasureRating, effectivePropertySet.TreasureRating > 0))
        {
            return false;
        }
        if (!TestBoolean(Vampiric, effectivePropertySet.Vampiric))
        {
            return false;
        }
        if (!TestBoolean(Wraith, effectivePropertySet.Wraith))
        {
            return false;
        }
        if (!TestBoolean(XtraMight, effectivePropertySet.XtraMight))
        {
            return false;
        }
        if (!TestBoolean(XtraShots, effectivePropertySet.XtraShots))
        {
            return false;
        }
        return true;
    }

    protected virtual bool? CanApplyBlessedArtifactBias => null;
    protected virtual bool? CanApplyArtifactBiasSlaying => null;

    protected virtual bool? HasActivation => null;

    public virtual bool? Aggravate => null;

    public virtual bool? AntiTheft => null;

    public virtual bool? ArtifactBias => null;

    public virtual bool? Blessed => null;

    public virtual bool? BrandAcid => null;

    public virtual bool? BrandCold => null;

    public virtual bool? BrandElec => null;

    public virtual bool? BrandFire => null;

    public virtual bool? BrandPois => null;

    public virtual bool? Chaotic => null;

    public virtual bool? IsCursed => null;

    public virtual bool? DrainExp => null;

    public virtual bool? DreadCurse => null;

    public virtual bool? EasyKnow => null;

    public virtual bool? Feather => null;

    public virtual bool? FreeAct => null;

    public virtual bool? HeavyCurse => null;

    public virtual bool? HideType => null;

    public virtual bool? HoldLife => null;

    public virtual bool? IgnoreAcid => null;

    public virtual bool? IgnoreCold => null;

    public virtual bool? IgnoreElec => null;

    public virtual bool? IgnoreFire => null;

    public virtual bool? ImAcid => null;

    public virtual bool? ImCold => null;

    public virtual bool? ImElec => null;

    public virtual bool? ImFire => null;

    public virtual bool? Impact => null;

    public virtual bool? NoMagic => null;

    public virtual bool? NoTele => null;

    public virtual bool? PermaCurse => null;

    public virtual bool? Radius => null;

    public virtual bool? Reflect => null;

    public virtual bool? Regen => null;

    public virtual bool? ResAcid => null;

    public virtual bool? ResBlind => null;

    public virtual bool? ResChaos => null;

    public virtual bool? ResCold => null;

    public virtual bool? ResConf => null;

    public virtual bool? ResDark => null;

    public virtual bool? ResDisen => null;

    public virtual bool? ResElec => null;

    public virtual bool? ResFear => null;

    public virtual bool? ResFire => null;

    public virtual bool? ResLight => null;

    public virtual bool? ResNether => null;

    public virtual bool? ResNexus => null;

    public virtual bool? ResPois => null;

    public virtual bool? ResShards => null;

    public virtual bool? ResSound => null;

    public virtual bool? SeeInvis => null;

    public virtual bool? FactoryAllowsShElecricity => null;

    public virtual bool? ShElec => null;

    public virtual bool? FactoryAllowsShFire => null;

    public virtual bool? ShFire => null;

    public virtual bool? ShowMods => null;

    public virtual bool? SlayAnimal => null;

    public virtual bool? SlayDemon => null;

    public virtual bool? SlayDragon => null;

    public virtual bool? SlayEvil => null;

    public virtual bool? SlayGiant => null;

    public virtual bool? SlayOrc => null;

    public virtual bool? SlayTroll => null;

    public virtual bool? SlayUndead => null;

    public virtual bool? SlowDigest => null;

    public virtual bool? SustCha => null;

    public virtual bool? SustCon => null;

    public virtual bool? SustDex => null;

    public virtual bool? SustInt => null;

    public virtual bool? SustStr => null;

    public virtual bool? SustWis => null;

    public virtual bool? Telepathy => null;

    public virtual bool? Teleport => null;

    public virtual bool? TreasureRating => null;

    public virtual bool? Vampiric => null;

    public virtual bool? Vorpal => null;

    public virtual bool? Wraith => null;

    public virtual bool? XtraMight => null;

    public virtual bool? XtraShots => null;
}
