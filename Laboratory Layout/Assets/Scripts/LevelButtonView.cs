using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButtonView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI levelIdLabel;
    [SerializeField] private List<GameObject> stars;

    public void SetupLevelButton(int levelId, int starsCount)
    {
        levelIdLabel.text = $"{levelId}";
        SetupStars(starsCount);
    }
    private void SetupStars(int starsCount)
    {
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].SetActive(i < starsCount);

        }    
    }
}
