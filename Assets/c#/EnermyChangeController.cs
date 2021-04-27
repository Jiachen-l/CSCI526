using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyChangeController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] characterCollection;
    static public int characterIndex_2;

    public bool changeCharacterActive;

    // flash effect
    private SpriteRenderer bodySprite;
    private SpriteRenderer headSprite;

    private bool flashActive;
    public float flashLength = 0.5f;
    public float flashCounter;
    void Start()
    {
        if (GameObject.Find("XRpro") != null)
        {
            bodySprite = GameObject.Find("Body").GetComponent<SpriteRenderer>();
            headSprite = GameObject.Find("Head").GetComponent<SpriteRenderer>();
        }

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
        if (flashActive)
        {
            if (GameObject.Find("XRpro") != null)
            {
                if (flashCounter > flashLength * .95f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .90f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .85f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .80f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .75f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .70f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .65f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .60f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .55f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .50f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .45f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .40f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .35f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .30f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .25f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .20f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .15f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else if (flashCounter > flashLength * .10f)
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                }
                else if (flashCounter > flashLength * .05f)
                {
                    bodySprite.color = Color.green;
                    headSprite.color = Color.green;
                }
                else
                {
                    bodySprite.color = Color.white;
                    headSprite.color = Color.white;
                    flashActive = false;
                }
                flashCounter -= Time.deltaTime;
            }
        }
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
            flashActive = true;
            flashCounter = flashLength;
        }

    }
}
