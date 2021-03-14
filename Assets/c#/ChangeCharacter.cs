﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{   
    public GameObject changeCharacterObject;
    public GameObject[] characterCollection;
    static public int characterIndex;

    public bool changeCharacterActive;

    // Start is called before the first frame update
    void Start()
    {
        characterIndex = 0;
        characterCollection[0].gameObject.SetActive(true);
        for (int i = 1; i < characterCollection.Length; i++)
        {
            characterCollection[i].gameObject.SetActive(false);
        }

        changeCharacterActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCharacterFunction();
    }

    void ChangeCharacterFunction()
	{
		if (changeCharacterActive)
		{   
            // move all characters' position to one position
            for (int i = 0; i < characterCollection.Length; i++)
            {   
                if (i != characterIndex)
                {
                    characterCollection[i].transform.position = characterCollection[characterIndex].transform.position;
                }
                Debug.Log(i + " " + characterCollection[i].transform.position);
            }

            // move change character object
            // changeCharacterObject.transform.position = characterCollection[characterIndex].transform.position;

            // switch character by switching character index
			characterIndex++;
			if(characterIndex >= characterCollection.Length)
			{
				characterIndex = 0;
			}
            for (int i = 0; i < characterCollection.Length; ++i)
            {
                characterCollection[i].gameObject.SetActive(false);
            }
            characterCollection[characterIndex].gameObject.SetActive(true);
            if (characterIndex == 1) {
                GameObject.Find("Main Camera").GetComponent<CameraColtroller>().target1 = GameObject.Find("bone_3").transform;
                GameObject.Find("Main Camera").GetComponent<CameraColtroller>().target2 = GameObject.Find("bone_4").transform;
            }
            else if (characterIndex == 0)
            {
                GameObject.Find("Main Camera").GetComponent<CameraColtroller>().target1 = GameObject.Find("XRpro").transform;
                GameObject.Find("Main Camera").GetComponent<CameraColtroller>().target2 = GameObject.Find("XRpro").transform;
            }

            changeCharacterActive = false;
		}

	}
}
