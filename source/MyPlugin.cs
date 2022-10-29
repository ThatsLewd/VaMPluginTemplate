using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;
using VaMUtils;

namespace ThatsLewd
{
  public class MyPlugin : MVRScript
  {
    Atom person = null;

    public override void Init()
    {
      if (containingAtom == null)
      {
        SuperController.LogError("MyPlugin must be attached to a Person atom!");
        return;
      }
      person = containingAtom;
      CreateUI();
    }

    void OnDestroy()
    {
      UIBuilder.Destroy();
    }

    void CreateUI()
    {
      UIBuilder.Init(this, CreateUIElement);
    }

    public void Update()
    {
      // Do stuff
    }

    public override JSONClass GetJSON(bool includePhysical = true, bool includeAppearance = true, bool forceStore = false)
    {
      JSONClass json = base.GetJSON(includePhysical, includeAppearance, forceStore);

      return json;
    }

    public override void LateRestoreFromJSON(JSONClass json, bool restorePhysical = true, bool restoreAppearance = true, bool setMissingToDefault = true)
    {
      base.LateRestoreFromJSON(json, restorePhysical, restoreAppearance, setMissingToDefault);
    }
  }
}
