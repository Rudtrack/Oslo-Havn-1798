using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Jørgen Steinset
//
//Not a very suitable name. It has player distance and thats nice

public class RealWorldSpaceManager : MonoBehaviour
{
    public GameObject distanceCheck; // gameObject child of door. 
    public GameObject target; // a plane set on the door for reference. 
    public GameObject image; // gameobject which shows icon in world space. 
    public GameObject knockAudio; // simple reference, not neccessary to add audiomanager. 
    public GameObject doorButton; // a button that is put infront of the door world space. 
    ///Knock AudioSource
    private AudioSource knock_aS;

    ///Image component from "image"
    private Image imageRenderer;
    /// sprites - interact icons.
    public Sprite close, far;

    public Light directionalLight;

    /// distance from player to scanned object in scene-units. 
    public float distance;

    /// change interact icon if more/less of this distance.
    private float changeSpriteDistance = 6;

    // - - Hacky Things - - //
    public float maximumDistance = 10;
    public float lightMulitplier = -9;
    public float lightIntensity;

    ///If 2 seconds have passed, don't enable this again. 
    private bool buttonDestroyed = false;

    private void Start()
    {
        imageRenderer = image.GetComponent<Image>();
        MeyerObj = GameObject.FindGameObjectWithTag("P_Meyer");
        MeyerAnim = MeyerObj.GetComponent<Animator>();
        knock_aS = knockAudio.GetComponent<AudioSource>();
    }

    void Update()
    {
        //Checks in-scene distance from "distanceCheck" on the door and the player. 
        distance = transform.position.magnitude + distanceCheck.transform.position.magnitude;

        AdjustLighting(distance);
        SetCorrectSprite(distance);
    }

    //Late update so that it is not affected by update / performance
    private void LateUpdate()
    {
        image.transform.position = target.transform.position;
    }

    //Increase lighting as you approach door. If intensity is <= 0.5, it remains 0.5;
    private void AdjustLighting(float dist)
    {
        lightIntensity = (dist - maximumDistance) / lightMulitplier;
        directionalLight.intensity = lightIntensity;

        if (directionalLight.intensity > 0.5f)
        {
            directionalLight.intensity = 0.5f;
        }
    }

    //if closer than int "changeSpriteDistance" in-game units, show interact icon and enable button. Else, set far icon and disable button. 
    private void SetCorrectSprite(float dist)
    {
        if (dist > changeSpriteDistance && imageRenderer.sprite != far)
        {
            ChangeSprite(far);
            doorButton.SetActive(false);
        }
        else if (dist < changeSpriteDistance && imageRenderer.sprite != close)
        {
            ChangeSprite(close);

            if (!buttonDestroyed)
                doorButton.SetActive(true);
        }
    }

    //Changes sprite only if needed. 
    private void ChangeSprite(Sprite spr)
    {
        imageRenderer.sprite = spr;
    }

    private Animator MeyerAnim;
    private GameObject MeyerObj;

    //Is executed by "DoorButton"
    public void KnockOnDoor() // played from button
    {
        MeyerAnim.SetTrigger("T_OpenDoor");
        knock_aS.Play();
        StartCoroutine(WaitForOpen());
    }

    //Disables door button and disables interact icon. 
    public IEnumerator WaitForOpen()
    {
        yield return new WaitForSeconds(2f);
        doorButton.SetActive(false);
        buttonDestroyed = true;

        imageRenderer.enabled = false;
        StopCoroutine(WaitForOpen());
    }

    public void EnableDoorButtonRWSM()
    {
        doorButton.SetActive(true);
        buttonDestroyed = false;

        imageRenderer.enabled = true;
    }
}
