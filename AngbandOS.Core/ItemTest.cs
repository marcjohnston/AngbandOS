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

    private bool TestZeroInt(bool? testValue, int actualValue)
    {
        if (testValue.HasValue)
        {
            if (testValue.Value == true && actualValue == 0)
            {
                return false;
            }
            if (testValue.Value == false && actualValue != 0)
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

    public bool Test(RwItemPropertySet characteristics)
    {
        if (!TestNullObject<Activation>(Activation, characteristics.Activation))
        {
            return false;
        }
        if (!TestBoolean(Aggravate, characteristics.Aggravate))
        {
            return false;
        }
        if (!TestBoolean(AntiTheft, characteristics.AntiTheft))
        {
            return false;
        }
        if (!TestNullObject<ArtifactBias>(ArtifactBias, characteristics.ArtifactBias))
        {
            return false;
        }
        if (!TestBoolean(Blessed, characteristics.Blessed))
        {
            return false;
        }
        if (!TestBoolean(Blows, characteristics.Blows))
        {
            return false;
        }
        if (!TestBoolean(BrandAcid, characteristics.BrandAcid))
        {
            return false;
        }
        if (!TestBoolean(BrandCold, characteristics.BrandCold))
        {
            return false;
        }
        if (!TestBoolean(BrandElec, characteristics.BrandElec))
        {
            return false;
        }
        if (!TestBoolean(BrandFire, characteristics.BrandFire))
        {
            return false;
        }
        if (!TestBoolean(BrandPois, characteristics.BrandPois))
        {
            return false;
        }
        if (!TestBoolean(Cha, characteristics.Cha))
        {
            return false;
        }
        if (!TestBoolean(Chaotic, characteristics.Chaotic))
        {
            return false;
        }
        if (!TestBoolean(Con, characteristics.Con))
        {
            return false;
        }
        if (!TestBoolean(IsCursed, characteristics.IsCursed))
        {
            return false;
        }
        if (!TestBoolean(Dex, characteristics.Dex))
        {
            return false;
        }
        if (!TestBoolean(DrainExp, characteristics.DrainExp))
        {
            return false;
        }
        if (!TestBoolean(DreadCurse, characteristics.DreadCurse))
        {
            return false;
        }
        if (!TestBoolean(EasyKnow, characteristics.EasyKnow))
        {
            return false;
        }
        if (!TestBoolean(Feather, characteristics.Feather))
        {
            return false;
        }
        if (!TestBoolean(FreeAct, characteristics.FreeAct))
        {
            return false;
        }
        if (!TestBoolean(HeavyCurse, characteristics.HeavyCurse))
        {
            return false;
        }
        if (!TestBoolean(HideType, characteristics.HideType))
        {
            return false;
        }
        if (!TestBoolean(HoldLife, characteristics.HoldLife))
        {
            return false;
        }
        if (!TestBoolean(IgnoreAcid, characteristics.IgnoreAcid))
        {
            return false;
        }
        if (!TestBoolean(IgnoreCold, characteristics.IgnoreCold))
        {
            return false;
        }
        if (!TestBoolean(IgnoreElec, characteristics.IgnoreElec))
        {
            return false;
        }
        if (!TestBoolean(IgnoreFire, characteristics.IgnoreFire))
        {
            return false;
        }
        if (!TestBoolean(ImAcid, characteristics.ImAcid))
        {
            return false;
        }
        if (!TestBoolean(ImCold, characteristics.ImCold))
        {
            return false;
        }
        if (!TestBoolean(ImElec, characteristics.ImElec))
        {
            return false;
        }
        if (!TestBoolean(ImFire, characteristics.ImFire))
        {
            return false;
        }
        if (!TestBoolean(Impact, characteristics.Impact))
        {
            return false;
        }
        if (!TestBoolean(Infra, characteristics.Infra))
        {
            return false;
        }
        if (!TestBoolean(InstaArt, characteristics.InstaArt))
        {
            return false;
        }
        if (!TestBoolean(Int, characteristics.Int))
        {
            return false;
        }
        if (!TestBoolean(KillDragon, characteristics.KillDragon))
        {
            return false;
        }
        if (!TestBoolean(NoMagic, characteristics.NoMagic))
        {
            return false;
        }
        if (!TestBoolean(NoTele, characteristics.NoTele))
        {
            return false;
        }
        if (!TestBoolean(PermaCurse, characteristics.PermaCurse))
        {
            return false;
        }
        if (!TestZeroInt(Radius, characteristics.Radius))
        {
            return false;
        }
        if (!TestBoolean(Reflect, characteristics.Reflect))
        {
            return false;
        }
        if (!TestBoolean(Regen, characteristics.Regen))
        {
            return false;
        }
        if (!TestBoolean(ResAcid, characteristics.ResAcid))
        {
            return false;
        }
        if (!TestBoolean(ResBlind, characteristics.ResBlind))
        {
            return false;
        }
        if (!TestBoolean(ResChaos, characteristics.ResChaos))
        {
            return false;
        }
        if (!TestBoolean(ResCold, characteristics.ResCold))
        {
            return false;
        }
        if (!TestBoolean(ResConf, characteristics.ResConf))
        {
            return false;
        }
        if (!TestBoolean(ResDark, characteristics.ResDark))
        {
            return false;
        }
        if (!TestBoolean(ResDisen, characteristics.ResDisen))
        {
            return false;
        }
        if (!TestBoolean(ResElec, characteristics.ResElec))
        {
            return false;
        }
        if (!TestBoolean(ResFear, characteristics.ResFear))
        {
            return false;
        }
        if (!TestBoolean(ResFire, characteristics.ResFire))
        {
            return false;
        }
        if (!TestBoolean(ResLight, characteristics.ResLight))
        {
            return false;
        }
        if (!TestBoolean(ResNether, characteristics.ResNether))
        {
            return false;
        }
        if (!TestBoolean(ResNexus, characteristics.ResNexus))
        {
            return false;
        }
        if (!TestBoolean(ResPois, characteristics.ResPois))
        {
            return false;
        }
        if (!TestBoolean(ResShards, characteristics.ResShards))
        {
            return false;
        }
        if (!TestBoolean(ResSound, characteristics.ResSound))
        {
            return false;
        }
        if (!TestBoolean(Search, characteristics.Search))
        {
            return false;
        }
        if (!TestBoolean(SeeInvis, characteristics.SeeInvis))
        {
            return false;
        }
        if (!TestBoolean(FactoryAllowsShElecricity, characteristics.CanProvideSheathOfElectricity))
        {
            return false;
        }
        if (!TestBoolean(ShElec, characteristics.ShElec))
        {
            return false;
        }
        if (!TestBoolean(FactoryAllowsShFire, characteristics.CanProvideSheathOfFire))
        {
            return false;
        }
        if (!TestBoolean(ShFire, characteristics.ShFire))
        {
            return false;
        }
        if (!TestBoolean(ShowMods, characteristics.ShowMods))
        {
            return false;
        }
        if (!TestBoolean(SlayAnimal, characteristics.SlayAnimal))
        {
            return false;
        }
        if (!TestBoolean(SlayDemon, characteristics.SlayDemon))
        {
            return false;
        }
        if (!TestBoolean(SlayDragon, characteristics.SlayDragon))
        {
            return false;
        }
        if (!TestBoolean(SlayEvil, characteristics.SlayEvil))
        {
            return false;
        }
        if (!TestBoolean(SlayGiant, characteristics.SlayGiant))
        {
            return false;
        }
        if (!TestBoolean(SlayOrc, characteristics.SlayOrc))
        {
            return false;
        }
        if (!TestBoolean(SlayTroll, characteristics.SlayTroll))
        {
            return false;
        }
        if (!TestBoolean(SlayUndead, characteristics.SlayUndead))
        {
            return false;
        }
        if (!TestBoolean(SlowDigest, characteristics.SlowDigest))
        {
            return false;
        }
        if (!TestBoolean(Speed, characteristics.Speed))
        {
            return false;
        }
        if (!TestBoolean(Stealth, characteristics.Stealth))
        {
            return false;
        }
        if (!TestBoolean(Str, characteristics.Str))
        {
            return false;
        }
        if (!TestBoolean(SustCha, characteristics.SustCha))
        {
            return false;
        }
        if (!TestBoolean(SustCon, characteristics.SustCon))
        {
            return false;
        }
        if (!TestBoolean(SustDex, characteristics.SustDex))
        {
            return false;
        }
        if (!TestBoolean(SustInt, characteristics.SustInt))
        {
            return false;
        }
        if (!TestBoolean(SustStr, characteristics.SustStr))
        {
            return false;
        }
        if (!TestBoolean(SustWis, characteristics.SustWis))
        {
            return false;
        }
        if (!TestBoolean(Telepathy, characteristics.Telepathy))
        {
            return false;
        }
        if (!TestBoolean(Teleport, characteristics.Teleport))
        {
            return false;
        }
        if (!TestZeroInt(TreasureRating, characteristics.TreasureRating))
        {
            return false;
        }
        if (!TestBoolean(Tunnel, characteristics.Tunnel))
        {
            return false;
        }
        if (!TestBoolean(Vampiric, characteristics.Vampiric))
        {
            return false;
        }
        if (!TestBoolean(Vorpal, characteristics.Vorpal))
        {
            return false;
        }
        if (!TestBoolean(Wis, characteristics.Wis))
        {
            return false;
        }
        if (!TestBoolean(Wraith, characteristics.Wraith))
        {
            return false;
        }
        if (!TestBoolean(XtraMight, characteristics.XtraMight))
        {
            return false;
        }
        if (!TestBoolean(XtraShots, characteristics.XtraShots))
        {
            return false;
        }
        return true;
    }

    protected virtual bool? Activation => null;

    public virtual bool? Aggravate => null;

    public virtual bool? AntiTheft => null;

    public virtual bool? ArtifactBias => null;

    public virtual bool? Blessed => null;

    public virtual bool? Blows => null;

    public virtual bool? BrandAcid => null;

    public virtual bool? BrandCold => null;

    public virtual bool? BrandElec => null;

    public virtual bool? BrandFire => null;

    public virtual bool? BrandPois => null;

    public virtual bool? Cha => null;

    public virtual bool? Chaotic => null;

    public virtual bool? Con => null;

    public virtual bool? IsCursed => null;

    public virtual bool? Dex => null;

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

    public virtual bool? Infra => null;

    public virtual bool? InstaArt => null;

    public virtual bool? Int => null;

    public virtual bool? KillDragon => null;

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

    public virtual bool? Search => null;

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

    public virtual bool? Speed => null;

    public virtual bool? Stealth => null;

    public virtual bool? Str => null;

    public virtual bool? SustCha => null;

    public virtual bool? SustCon => null;

    public virtual bool? SustDex => null;

    public virtual bool? SustInt => null;

    public virtual bool? SustStr => null;

    public virtual bool? SustWis => null;

    public virtual bool? Telepathy => null;

    public virtual bool? Teleport => null;

    public virtual bool? TreasureRating => null;

    public virtual bool? Tunnel => null;

    public virtual bool? Vampiric => null;

    public virtual bool? Vorpal => null;

    public virtual bool? Wis => null;

    public virtual bool? Wraith => null;

    public virtual bool? XtraMight => null;

    public virtual bool? XtraShots => null;
}
