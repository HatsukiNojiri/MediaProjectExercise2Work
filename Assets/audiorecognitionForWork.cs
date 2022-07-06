using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;

public class audiorecognitionForWork : MonoBehaviour
{
    public Text InputText;
    public GameObject anoneObj;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        //認識したい単語の登録
        keywords.Add("あのね", () => { });
        keywords.Add("ときをもどそう", () => { });
        keywords.Add("あしだまな", () => { });
        keywords.Add("ぺこぱ", () => { });

        //音声認識イベントの登録
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecoggnizer_OnPhaseRecognized;

        keywordRecognizer.Start();
        Debug.Log("音声認識開始");
        InputText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //単語が読み上げられた場合のイベント処理
    private void KeywordRecoggnizer_OnPhaseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        switch (args.text)
        {
            case "あのね":
                Debug.Log("あのね");
                InputText.text += "あのね";
                anoneObj.SetActive(true);
                Instantiate(anoneObj);
                break;
            case "ときをもどそう":
                Debug.Log("ときをもどそう");
                InputText.text += "ときをもどそう";
                break;
            case "あしだまな":
                Debug.Log("芦田愛菜");
                InputText.text += "芦田愛菜";
                break;
            case "ぺこぱ":
                Debug.Log("ペコパ");
                InputText.text += "ペコパ";
                break;
        }
    }
}
