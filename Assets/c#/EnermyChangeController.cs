using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyChangeController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] characterCollection;
    static public int characterIndex_2;

    public bool changeCharacterActive;
    void Start()
    {
        characterIndex_2 = 0;
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
            // for (int i = 0; i < characterCollection.Length; i++)
            // {   
            //     if (i != characterIndex_2)
            //     {
            //         characterCollection[i].transform.position = characterCollection[characterIndex_2].transform.position;
            //     }
            //     Debug.Log(i + " " + characterCollection[i].transform.position);
            // }

            // move change character object
            // changeCharacterObject.transform.position = characterCollection[characterIndex].transform.position;

            // switch character by switching character index
			characterIndex_2++;
			if(characterIndex_2 >= characterCollection.Length)
			{
				characterIndex_2 = 0;
			}
            for (int i = 0; i < characterCollection.Length; ++i)
            {
                characterCollection[i].gameObject.SetActive(false);
            }
            characterCollection[characterIndex_2].gameObject.SetActive(true);

            changeCharacterActive = false;
		}

	}
}
