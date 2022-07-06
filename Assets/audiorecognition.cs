using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;

//参考： https://docs.microsoft.com/ja-jp/windows/mixed-reality/voice-input-in-unity

public class audiorecognition : MonoBehaviour
{
    public Text Inputtext;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    // Start is called before the first frame update
    void Start()
    {
        // 認識したい単語の登録
        keywords.Add("うえ", () => { }); //{}の中に処理内容を記述してもよい
        keywords.Add("した", () => { }); //その場合は、keywordAction.Invoke()で呼び出す
        keywords.Add("ひだり", () => { });
        keywords.Add("みぎ", () => { });

        //音声認識イベントの登録
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhaseRecognized;

        keywordRecognizer.Start();
        Debug.Log("音声認識開始");
        Inputtext.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    //単語が読み上げられた場合のイベント処理
    private void KeywordRecognizer_OnPhaseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        /* keywords.Addの{}内に処理を記入した場合
        if(keywords.TryGetValue(args.text, out keywordAction))
        {
        keywordAction.Invoke();
        }
        */
        switch (args.text)
        {
            case "うえ":
                Debug.Log("うえ");
                Inputtext.text += "上";
                break;
            case "した":
                Debug.Log("した");
                Inputtext.text += "下";
                break;
            case "ひだり":
                Debug.Log("ひだり");
                Inputtext.text += "左";
                break;
            case "みぎ":
                Debug.Log("みぎ");
                Inputtext.text += "右";
                break;
        }
    }
}