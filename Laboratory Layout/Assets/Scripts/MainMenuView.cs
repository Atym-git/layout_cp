using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{

    [SerializeField] private Button playButton;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private RectTransform root;
    [SerializeField] private int levelCount = 0;

    private const int _minstarscount = 0;
    private const int _maxstarscount = 4;

    void Start()
    {
        levelMenu.SetActive(false);
        playButton.onClick.AddListener(OnplayButtonPressed);
        //playButton.onClick.AddListener(FillLevelMenu);

    }

    private void OnplayButtonPressed()
    {
        playButton.gameObject.SetActive(false);
        ClearLevelMenu();
        FillLevelMenu();
        levelMenu.SetActive(true);
    }


    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(OnplayButtonPressed);
    }

    private void FillLevelMenu()
    { 
    for(int i = 0; i < levelCount; i++)
        {
            GameObject levelbutton = Instantiate(levelButtonPrefab, root);
            if (levelbutton.TryGetComponent(out LevelButtonView LevelButtonView))
                
            {

                LevelButtonView.SetupLevelButton(i + 1, UnityEngine.Random.Range(_minstarscount, _maxstarscount));
            }

        }
    
    }

    private void ClearLevelMenu()
    {
        for(int i = 0; i < root.childCount; i++)
        {
            Destroy(root.GetChild(i).gameObject);
        }
    }



}
