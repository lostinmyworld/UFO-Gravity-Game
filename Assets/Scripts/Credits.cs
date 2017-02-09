using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    public Sprite[] Images;
    public Image ImageToSet;

    public Text titleText;
    public Text subtitleText;

    private int currentCreditLevel = 0;
    private string[] TitleString;
    private string[] SubtitleString;

	void Start()
	{
        titleText.text = "";
        subtitleText.text = "";

        TitleString = new string[2] { "Game Development", "Professor" };
        SubtitleString = new string[2] { "Katsampiris Panagiotis", "Thanos Voulodimos" };

        
        SetCredits();
	}

    public void SetCredits()
    {
        if (currentCreditLevel < Images.Length) {
            ImageToSet.sprite = Images[currentCreditLevel];
            titleText.text = TitleString[currentCreditLevel];
            subtitleText.text = SubtitleString[currentCreditLevel];
        } else {
            Application.Quit();
        }
        currentCreditLevel++;
    }
}
