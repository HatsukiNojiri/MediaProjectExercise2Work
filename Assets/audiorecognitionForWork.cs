using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;

public class audiorecognitionForWork : MonoBehaviour
{
    public Text InputText;
    public GameObject PlusObj;
    public GameObject PlusSph;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private List<GameObject> ObjList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //認識したい単語の登録
        keywords.Add("ときをもどそう", () => { });
        keywords.Add("ふえろ", () => { });
        keywords.Add("まる", () => { });
        //立体移動
        keywords.Add("まえ", () => { });
        keywords.Add("うしろ", () => { });
        keywords.Add("みぎ", () => { });
        keywords.Add("ひだり", () => { });
        keywords.Add("うえ", () => { });
        keywords.Add("した", () => { });

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
            case "ときをもどそう":
                Debug.Log("ときをもどそう");
                InputText.text += "ときをもどそう";
                DestroyPrefab();
                break;
            case "ふえろ":
                Debug.Log("ふえろ");
                InputText.text += "増えろ";
                CreatePrefab(PlusObj);
                break;
            case "まる":
                Debug.Log("まる");
                //生成位置
                Vector3 PrefabPos = new Vector3(0.0f, 10.0f, 0.0f);
                //プレハブを指定位置に生成
                Instantiate(PlusSph, PrefabPos, Quaternion.identity);
                break;
            //立体操作
            case "まえ":
                Debug.Log("まえ");
                break;
            case "うしろ":
                Debug.Log("うしろ");
                break;
            case "みぎ":
                Debug.Log("みぎ");
                break;
            case "ひだり":
                Debug.Log("ひだり");
                break;
            case "うえ":
                Debug.Log("うえ");
                break;
            case "した":
                Debug.Log("した");
                break;
        }
    }

    public void CreatePrefab(GameObject PrefabObj)
    {
        //生成位置
        Vector3 PrefabPos = new Vector3(0.0f, 10.0f, 0.0f);
        //プレハブを指定位置に生成
        ObjList.Add(Instantiate(PrefabObj, PrefabPos, Quaternion.identity));
    }

    public void DestroyPrefab()
    {
        //Destroy
        foreach (GameObject se in ObjList)
        {
            Destroy(se);
        }
    }
}
