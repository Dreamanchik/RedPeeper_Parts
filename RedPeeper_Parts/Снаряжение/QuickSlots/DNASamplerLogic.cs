using RedPeeper_Parts;
using UnityEngine;

internal class DNASamplerLogic : PlayerTool
{
    public override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        /*bool busy = this._busy;
        string result;
        if (busy)
        {
            result = Language.main.Get("GayBusy");
        }
        else
        {
            bool flag = Time.time < this._lastFailTime + 2f;
            if (flag)
            {
                result = Language.main.Get("GayFail");
            }
            else
            {
                result = LanguageCache.GetButtonFormat("Gay", GameInput.Button.RightHand);
            }
        }
        return result;*/
        string buttonFormat = LanguageCache.GetButtonFormat("Наведитесь на фауну для синтеза ДНК", GameInput.Button.RightHand);
        string inventoryFull = LanguageCache.GetButtonFormat("Инвентарь полон", GameInput.Button.PDA);
        if (this.usingPlayer.HasInventoryRoom(1, 1))
        {
            HandReticle.main.SetTextRaw(HandReticle.TextType.Use, buttonFormat);
        }
        else
        {
            HandReticle.main.SetTextRaw(HandReticle.TextType.UseSubscript, inventoryFull);
        }
    }
    public override bool OnRightHandDown()
    {
        if (Player.main.IsBleederAttached())
        {
            return true;
        }
        bool busy = this._busy;
        bool result;
        if (busy)
        {
            result = false;
        }
        else
        {
            GameObject gameObject;
            float num;
            bool target = Targeting.GetTarget(Player.main.gameObject, 3f, out gameObject, out num);
            if (target)
            {
                EnergyMixin energyMixin = this.energyMixin;

                //LiveMixin liveMixin = gameObject.GetComponent<LiveMixin>();
                string id = gameObject.GetComponent<PrefabIdentifier>().classId;
                //bool flag = liveMixin == null;
                //if (!flag)
                //{
                    if (energyMixin.charge >= 1f)
                    {
                        if (CreatureList.Creatures.ContainsKey(id)) 
                        {
                            if (this.usingPlayer.HasInventoryRoom(1, 1))
                            {
                                CraftData.AddToInventory(CreatureList.Creatures[id]);
                                energyMixin.ConsumeEnergy(100f);
                                //ErrorMessage.AddMessage("AAAAAAAAAAAAAAAA");
                            }
                        }
                    }
                //}
            }
            result = true;
        }
        return result;
    }
    public override string animToolName
    {
        get
        {
            return TechType.Scanner.AsString(true);
        }
    }
    private void LateUpdate ()
    {
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    public override void OnHolster()
    {
        base.OnHolster();
    }
    private bool _busy;
    private float _lastFailTime = -100f;
}