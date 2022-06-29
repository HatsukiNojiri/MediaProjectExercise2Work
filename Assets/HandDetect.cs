//Collections: https://developer-archive.leapmotion.com/documentation/asharp/api/gen-csharp/class_leap_1_1_controller.html?highlight=controller
//frame: https://developer-archive.leapmotion.com/documentation/v2/unity/api/Leap.Frame.html
// interaction_box: https://developer-archive.leapmotion.com/documentation/csharp/api/gen-csharp/struct_leap_1_1_interaction_box.html
//Finger: https://developer-archive.leapmotion.com/documentation/csharp/api/Leap.Finger.html#id2
//指の認識: https://www.buildinsider.net/samll/leapmotioncs/03

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HandDetect : MonoBehaviour
{
    Controller controller = new Controller();
    public int FingerCount;
    public GameObject[] FingerObjects;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.IsConnected)
        {
            Frame CurrentFrame = controller.Frame();//フレームから検出した手・指のセット
            FingerCount = CurrentFrame.Fingers.Count;//指の数
            //leap motion情でbox型の空間(interactionbox:0～1)を定義する
            InteractionBox interactionBox = CurrentFrame.InteractionBox;

            for(int i = 0; i < FingerObjects.Length; i++)
            {
                var leapFinger = CurrentFrame.Fingers[i];
                var unityFinger = FingerObjects[i];
                if (leapFinger.IsValid)
                {
                    //leapmotionから取得した位置座標をinteractionbox(0から1)に正規化する
                    Vector normalizedCoodinates = interactionBox.NormalizePoint(leapFinger.TipPosition);
                    normalizedCoodinates *= 10;
                    //Leapmotion:右手座標系からunityの左手座標系に変換
                    normalizedCoodinates.z = -normalizedCoodinates.z;
                    unityFinger.transform.localPosition = new Vector3(normalizedCoodinates.x - 5, normalizedCoodinates.y, normalizedCoodinates.z);
                    //cubeオブジェクトの表示
                    foreach(Renderer component in unityFinger.GetComponents<Renderer>())
                    {
                        component.enabled = leapFinger.IsValid;
                    }
                }
            }
        }
    }
}
