using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using VaMLib;

namespace YOUR_CREATOR_NAME
{
  public class MyPlugin : MVRScript
  {
    Atom person;
    DAZCharacterSelector geometry;

    VaMUI.VaMToggle exampleToggle;
    VaMUI.VaMSlider exampleSlider;

    public override void Init()
    {
      person = containingAtom;
      geometry = containingAtom?.GetStorableByID("geometry") as DAZCharacterSelector;
      if (person == null || geometry == null)
      {
        LogError("MyPlugin must be attached to a Person atom!");
        return;
      }
      CreateUI();
    }

    void OnDestroy()
    {
      VaMUI.Destroy();
    }

    void CreateUI()
    {
      VaMUI.Init(this, CreateUIElement);

      exampleToggle = VaMUI.CreateToggle("Example Toggle", false, callback: (bool val) => { LogMessage($"EXAMPLE TOGGLE: {val}"); });
      exampleToggle.Draw(VaMUI.LEFT);

      exampleSlider = VaMUI.CreateSlider("Example Slider", 5f, 0f, 10f, callback: (float val) => { LogMessage($"EXAMPLE SLIDER: {val}"); });
      exampleSlider.Draw(VaMUI.LEFT);

      VaMUI.CreateButton(VaMUI.RIGHT, "Example Button", color: VaMUI.YELLOW, callback: () => { LogMessage("EXAMPLE BUTTON"); });
    }

    public void Update()
    {
      // Do stuff
    }

    public override JSONClass GetJSON(bool includePhysical = true, bool includeAppearance = true, bool forceStore = false)
    {
      JSONClass json = base.GetJSON(includePhysical, includeAppearance, forceStore);
      this.needsStore = true;

      // Save custom JSON here

      return json;
    }

    public override void LateRestoreFromJSON(JSONClass json, bool restorePhysical = true, bool restoreAppearance = true, bool setMissingToDefault = true)
    {
      base.LateRestoreFromJSON(json, restorePhysical, restoreAppearance, setMissingToDefault);
      if (json["id"]?.Value != this.storeId) return; // make sure this data is our plugin

      // Load custom JSON here
    }

    public static void LogMessage(string message)
    {
      SuperController.LogMessage($"[MyPlugin] {message}");
    }

    public static void LogError(string message)
    {
      SuperController.LogError($"[MyPlugin] {message}");
    }
  }
}
