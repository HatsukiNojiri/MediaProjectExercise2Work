using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Create : MonoBehaviour
{
    public GameObject PrefabObj;
    public GameObject bowObj;
    public GameObject jama1;
    public GameObject jama2;
    public UnityEngine.UI.Text scoreText;
    private bool isCreate = false;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        keywords.Add("すたあと", () => { });
        keywords.Add("すとっぷ", () => { });
        keywords.Add("りせっと", () => { });
        keywords.Add("かんたん", () => { });
        keywords.Add("ふつう", () => { });
        keywords.Add("むずかしい", () => { });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecoggnizer_OnPhaseRecognized;

        keywordRecognizer.Start();
        Debug.Log("音声認識開始1");
    }

    // Update is called once per frame
    void Update()
    {
        if(isCreate == true)
        {
            createRandom();
        }
    }

    private void createRandom()
    {
        if (Time.frameCount % 60 == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            float z = Random.Range(-3.0f, 3.0f);
            Vector3 pos = new Vector3(x, 20.0f, z);

            Instantiate(PrefabObj, pos, Quaternion.identity);
        }
    }

    private void KeywordRecoggnizer_OnPhaseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        switch (args.text)
        {
            case "すたあと":
                Debug.Log("スタート");
                isCreate = true;
                break;
            case "すとっぷ":
                Debug.Log("ストップ");
                isCreate = false;
                break;
            case "りせっと":
                Debug.Log("リセット");
                isCreate = false;
                scoreText.text = "0";
                break;
            case "かんたん":
                Debug.Log("簡単");
                bowObj.SetActive(false);
                jama1.SetActive(false);
                jama2.SetActive(false);
                break;
            case "ふつう":
                Debug.Log("普通");
                bowObj.SetActive(false);
                jama1.SetActive(true);
                jama2.SetActive(false);
                break;
            case "むずかしい":
                Debug.Log("難しい");
                bowObj.SetActive(true);
                jama1.SetActive(true);
                jama2.SetActive(true);
                break;
        }
    }
}
