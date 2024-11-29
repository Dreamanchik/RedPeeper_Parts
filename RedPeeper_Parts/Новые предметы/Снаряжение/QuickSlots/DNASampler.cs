using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using UnityEngine;
using Ingredient = CraftData.Ingredient;

    public static class DNASampler
    {
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType("DNASampler", "Shitcrap", "D")
            .WithIcon(SpriteManager.Get(TechType.HeatBlade));

        public static void Register()
        {
            var customPrefab = new CustomPrefab(Info);

            var yeetKnifeObj = new CloneTemplate(Info, TechType.Scanner);
            yeetKnifeObj.ModifyPrefab += obj =>
            {
                var yeetKnife = obj.AddComponent<DNASamplerData>();
                yeetKnife.damage *= 2f;
            };
            customPrefab.SetGameObject(yeetKnifeObj);
            customPrefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 2)));
            customPrefab.SetEquipment(EquipmentType.Hand);
            customPrefab.Register();
        }
    }

    public class DNASamplerData : HeatBlade
    {
        public float hitForce = 1669;
        public ForceMode forceMode = ForceMode.Acceleration;

        public override string animToolName { get; } = TechType.Scanner.AsString(true);

        public override void OnToolUseAnim(GUIHand hand)
        {
            base.OnToolUseAnim(hand);

            GameObject hitObj = null;
            Vector3 hitPosition = default;
            UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, attackDist, ref hitObj, ref hitPosition);
            if (!hitObj)
            {
                // Nothing is in our attack range. Exit method.
                return;
            }

            var liveMixin = hitObj.GetComponentInParent<LiveMixin>();
            if (liveMixin && IsValidTarget(liveMixin))
            {
                var rigidbody = hitObj.GetComponentInParent<Rigidbody>();

                if (rigidbody)
                {
                    rigidbody.AddForce(MainCamera.camera.transform.forward * hitForce, forceMode);
                }
            }
        }
    }