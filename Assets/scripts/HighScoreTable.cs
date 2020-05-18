using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {


        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{score = 521854,name = "AAA"},
            new HighScoreEntry{score = 358462,name = "ANN"},
            new HighScoreEntry{score = 785123,name = "CAT"},
            new HighScoreEntry{score = 15524,name = "JON"},
            new HighScoreEntry{score = 897621,name = "JOE"},
            new HighScoreEntry{score = 68245,name = "MIK"},
            new HighScoreEntry{score = 872931,name = "DAV"},
            new HighScoreEntry{score = 542024,name = "MAX"},


        };

        for (int i = 0; i < highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScoreEntryList.Count; j++)
            {
                if (highScoreEntryList[j].score > highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                }
            }
            highScoreEntryTransformList = new List<Transform>();

            foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
            {
                CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
            }


            JsonUtility.ToJson(highScoreEntryList);   
            PlayerPrefs.SetString("highscoreTable", "100");
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString("highscoreTable"));

        }
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry,Transform Container, List<Transform>TransformList)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, Container);
        RectTransform entryRectTranform = entryTransform.GetComponent<RectTransform>();
        entryRectTranform.anchoredPosition = new Vector2(0, -templateHeight * TransformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = TransformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        int score = highScoreEntry.score;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        TransformList.Add(entryTransform);
    }

    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
