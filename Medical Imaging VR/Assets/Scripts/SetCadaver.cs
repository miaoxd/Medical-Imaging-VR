﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SetCadaver : MonoBehaviour {


    public DisplayBody bodyDisplayer;
    // Use this for initialization
    void Start()
    {

        string fname = constructAssetFilename();
        //string fname = "13_1_1-Asset";
        Texture3D cadaverVolume = Resources.Load("Cadaver Assets/" + fname, typeof(Texture3D)) as Texture3D;
        if (cadaverVolume == null)
            throw new FileNotFoundException();

        //set the shader property.
        GetComponent<Renderer>().material.SetTexture("Cadaver_Data", cadaverVolume);
    }

    string constructAssetFilename()
    {
        GameObject displayBodyComponent = GameObject.Find("SceneControl");
        if (displayBodyComponent == null)
        {
            this.enabled = false;
            print("ERROR");
        }
        bodyDisplayer = displayBodyComponent.GetComponent<DisplayBody>();
        Destroy(displayBodyComponent);
        return (bodyDisplayer.DisplayId + "-Asset");
    }
}
