using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class CreaterController : MonoBehaviour
{
    public GameObject FallObj;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        keywords.Add("まえ", () => { });
        keywords.Add("うしろ", () => { });
        keywords.Add("みぎ", () => { });
        keywords.Add("ひだり", () => { });

        keywords.Add("おちろ", () => { });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecoggnizer_OnPhaseRecognized;

        keywordRecognizer.Start();
        Debug.Log("音声認識開始");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //単語が読み上げられた場合のイベント処理
    private void KeywordRecoggnizer_OnPhaseRecognized(PhraseRecognizedEventArgs args)
    {
        Vector3 pos = this.gameObject.transform.position;

        System.Action keywordAction;
        switch (args.text)
        {
            case "まえ":
                Debug.Log("前");
                pos.z -= 1.0f;
                this.gameObject.transform.position = pos;
                break;
            case "うしろ":
                Debug.Log("後");
                pos.z += 1.0f;
                this.gameObject.transform.position = pos;
                break;
            case "みぎ":
                Debug.Log("右");
                pos.x += 1.0f;
                this.gameObject.transform.position = pos;
                break;
            case "ひだり":
                Debug.Log("左");
                pos.x -= 1.0f;
                this.gameObject.transform.position = pos;
                break;
            case "おちろ":
                Debug.Log("落ちろ");
                pos.y -= 1.0f;
                Instantiate(FallObj, pos, Quaternion.identity);
                break;
        }
    }

}
