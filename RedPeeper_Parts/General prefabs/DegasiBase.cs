using JetBrains.Annotations;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DegasiBase : ICustomPrefab
{

    public PrefabInfo Info => throw new NotImplementedException();

    public PrefabFactoryAsync Prefab => throw new NotImplementedException();

    public PrefabPostProcessorAsync OnPrefabPostProcess => throw new NotImplementedException();

    public static void Register()
    {

    }

    public TGadget AddGadget<TGadget>(TGadget gadget) where TGadget : Gadget
    {
        throw new NotImplementedException();
    }

    public void AddOnRegister(Action onRegisterCallback)
    {
        throw new NotImplementedException();
    }

    public void AddOnUnregister(Action onUnregisterCallback)
    {
        throw new NotImplementedException();
    }

    public Gadget GetGadget(Type gadgetType)
    {
        throw new NotImplementedException();
    }

    public TGadget GetGadget<TGadget>() where TGadget : Gadget
    {
        throw new NotImplementedException();
    }

    public bool RemoveGadget(Type gadget)
    {
        throw new NotImplementedException();
    }

    public bool RemoveGadget<TGadget>() where TGadget : Gadget
    {
        throw new NotImplementedException();
    }

    public bool TryAddGadget<TGadget>(TGadget gadget) where TGadget : Gadget
    {
        throw new NotImplementedException();
    }

    public bool TryGetGadget<TGadget>(out TGadget gadget) where TGadget : Gadget
    {
        throw new NotImplementedException();
    }
}

