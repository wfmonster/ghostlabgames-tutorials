using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// objects can be active or inactive 
// components are either enabled or disabled.

public class LifeCycleTest : MonoBehaviour {


    // int updateCount = 0;

    // this is the field in the inspector where we added the name
    [SerializeField] string objectName; 

    // creates a variable to store a reference to our coin audio.
    AudioSource objectAudio;

    GameObject player;
    

    // is activated at the GameObject level when the game object is activated
    // only called once
    void Awake() {
	    Debug.Log("Hello, from Awake: " + objectName);
        objectAudio = GetComponent<AudioSource>();

        // can safely use find with tag
        player = GameObject.FindWithTag("Player");
        if(player){
            Debug.Log("Found Player");
        }

        // Don't do this, may work but can be unreliable, or cause unexected behavior, In playermovement  playerHealth is initialized to 100 but because it is accessing it before its initialized we get 0
        //  Debug.Log("Player Health: " + player.GetComponent<PlayerMovement>().playerHealth);   
        
    }

     // Start() and OnEnable() are activated at the component level when this script component is enabled.
    // OnEnable() is called everytime the component is reenabled.
    void OnEnable() {
        Debug.Log("Hello, from OnEnable " + objectName);
        objectAudio.Play();
    }

    
    // Start() is only called once, the first time the component is enabled.
    void Start() {
        Debug.Log("Hello, from Start: " + objectName);


        // grabbing the reference to the audio component here can cause a NullRefrenceException
        // objectAudio = GetComponent<AudioSource>(); 
        // objectAudio.Play(); 


        // Will work correctly here.
        Debug.Log("Player Health: " + player.GetComponent<PlayerMovement>().playerHealth);  

    }

   

    // Called every frame
    void Update() {
        
        // if (updateCount < 1){
        //      Debug.Log("Hello, from Update: " + objectName);
        //      updateCount += 1;
        // }
    }


}
