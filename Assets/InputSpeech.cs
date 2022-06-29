using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSpeech : MonoBehaviour
{
    public GameObject Cube;
    public Text outputText;
    private Text inputSpeech;
    private string str1 = "";
    private int strNum = 0;

    //Use this for initialization
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        inputSpeech = this.GetComponent<Text>();

        //追加の音声入力がされた場合
        if(strNum != inputSpeech.text.Length)
        {
            str1 = inputSpeech.text.Substring(strNum); //追加音声の切り出し
            outputText.text = str1; //音声の出力
            strNum = inputSpeech.text.Length; //音声の文字数

            Vector3 position = Cube.transform.position; //Cubeの座標取得
            //文字列の比較,Cubeの移動
            if(str1 == "上")
            {
                position.z += 1.0f;
                Cube.transform.position = position;
            }
            if (str1 == "下")
            {
                position.z -= 1.0f;
                Cube.transform.position = position;
            }
            if (str1 == "左")
            {
                position.x -= 1.0f;
                Cube.transform.position = position;
            }
            if (str1 == "右")
            {
                position.x += 1.0f;
                Cube.transform.position = position;
            }
        }
    }
}
