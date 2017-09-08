using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrack : MonoBehaviour
{

	void Start ()
	{
		//для неперывного звучания саундтрека
		DontDestroyOnLoad (gameObject);

	}

}
