using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParallaxController : MonoBehaviour
{
    [Space(10)]
    [SerializeField]
    private Transform genericResetPosition;

    [Space(10)]
    [Tooltip("General speed for all components")]
    [SerializeField]
    public float panningSpeed;

    [Space(10)]
    [SerializeField]
    private List<ParallaxLayer> layers = new List<ParallaxLayer>();

    private Dictionary<LayerPriority, ParallaxLayer> layerDictionary = new Dictionary<LayerPriority, ParallaxLayer>();

    private void Awake()
    {
        LayerPriority tempLayer = LayerPriority.First;

        for (int i = 0; i < layers.Count; i++)
        {
            tempLayer = (LayerPriority)i;

            layerDictionary.Add(tempLayer, layers[i]);

            layers[i].lastImageReseted = layers[i].parallaxComponents.Count - 1;
        }
    }

    public float GetResetPosition(LayerPriority layer, SpriteRenderer imageToReset)
    {
        float resetPos = 0;

        ParallaxLayer parallaxLayer = layerDictionary[layer];

        //If the layer is not secuencial, just reset the pos to a generic point and keep it moving

        if (!parallaxLayer.hasSecuencialReset || parallaxLayer.parallaxComponents.Count == 1)
        {
            resetPos = genericResetPosition.position.y;
            return resetPos;
        }

        SpriteRenderer lastImage = parallaxLayer.parallaxComponents[parallaxLayer.lastImageReseted];

        //Set the reset pos to be behind the las image reseted + his size
        resetPos = lastImage.transform.position.y + (lastImage.bounds.size.y - 0.2f);

        //Find the image that called the reset to set it as the last image reseted
        parallaxLayer.lastImageReseted = parallaxLayer.parallaxComponents.IndexOf(imageToReset);

        return resetPos;
    }

    public float GetParallaxMultipliyer(LayerPriority layer)
    {
        float parallaxMultipliyer = 0;

        parallaxMultipliyer = layerDictionary[layer].parallaxMultipliyer;

        return parallaxMultipliyer;
    }

    public void StopParallax()
    {
        panningSpeed = 0;
    }
}

[System.Serializable]
public class ParallaxLayer
{
    [Tooltip("If the images have to reset one after another or are separate")]
    public bool hasSecuencialReset = true;

    [Tooltip("Speed multipliyer for the components, the higher the faster they go")]
    public float parallaxMultipliyer;

    public List<SpriteRenderer> parallaxComponents;

    [HideInInspector]
    public int lastImageReseted;

    public ParallaxLayer(float parallaxMultipliyer, List<SpriteRenderer> parallaxComponents)
    {
        this.parallaxMultipliyer = parallaxMultipliyer;
        this.parallaxComponents = parallaxComponents;
    }
}

public enum LayerPriority
{
    First,
    Second,
    Third,
    Fourth,
    Five
}