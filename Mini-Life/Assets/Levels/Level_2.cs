using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_2 : MonoBehaviour
{
    public Text levelText;
    public float timeInSeconds;

    private void Start()
    {
        levelText.text = $"Time to next level: {timeInSeconds}";
        StartCoroutine(LevelTimer());
    }

    IEnumerator LevelTimer()
    {
        while (timeInSeconds > 0)
        {
            yield return new WaitForSeconds(1f);
            timeInSeconds--;
            levelText.text = $"Time to next level: {timeInSeconds}";

            if (timeInSeconds == 0)
            {
                GameManager.Instance.NextLevelMenu();
            }
        }
    }


}
