﻿using Walgelijk;

namespace MIR;

public class FlyingAbilityComponent : CharacterAbilityComponent
{
    public override string DisplayName => "Flying"; //👩
    private float progress = 0;

    public FlyingAbilityComponent(AbilitySlot slot) : base(slot, AbilityBehaviour.Toggle)
    {
    }

    public override void StartAbility(AbilityParams a)
    {
    }

    public override void UpdateAbility(AbilityParams a)
    {
        const float transitionTime = 0.4f;

        if (IsUsing)
            progress += a.Time.DeltaTime / transitionTime;
        else
            progress -= a.Time.DeltaTime / transitionTime;

        progress = float.Clamp(progress, 0, 1);
        float anim = Easings.Cubic.Out(progress);

        float s = float.Sin(a.Time * 4) * float.Abs(a.Character.Positioning.FlyingVelocity * 0.002f);
        a.Character.Positioning.FlyingOffset = float.Lerp(0, Utilities.MapRange(-1, 1, 500, 600, s), anim);
    }

    public override void EndAbility(AbilityParams a)
    {
    }
}
