using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class ObjectMove : MonoBehaviour
{
    Controller controller = new Controller();

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        bool righthandexist = false;
        bool lefthandexist = false;
        Vector righthand = null;
        InteractionBox interactionBox = frame.InteractionBox;
        foreach(Hand hand in frame.Hands)
        {
            float valZ = 0f;
            if (hand.IsLeft)
            {
                Debug.Log("left");
                lefthandexist = true;
                var Thumber = frame.Fingers[0];//親指
                var Pinky = frame.Fingers[4];//小指
                if(Thumber.IsValid && Pinky.IsValid)
                {
                    Vector nThumbPos = interactionBox.NormalizePoint(Thumber.TipPosition);
                    Vector nPinkyPos = interactionBox.NormalizePoint(Pinky.TipPosition);
                    //親指と小指のy座標軸の差によって移動量を決定
                    valZ = nThumbPos.y - nPinkyPos.y;
                }
                //左、z方向に移動
                transform.Translate(-0.01f, 0f, 0.1f * valZ);
            }
            if (hand.IsRight)
            {
                Debug.Log("right");
                righthandexist = true;
                var Thumber = frame.Fingers[0];
                var Pinky = frame.Fingers[4];
                if(Thumber.IsValid && Pinky.IsValid)
                {
                    Vector nThumbPos = interactionBox.NormalizePoint(Thumber.TipPosition);
                    Vector nPinkypos = interactionBox.NormalizePoint(Pinky.TipPosition);
                    valZ = nThumbPos.y - nPinkypos.y;
                }
                transform.Translate(0.01f, 0f, 0.1f * valZ);
            }
            if(lefthandexist && righthandexist)
            {
                Debug.Log("both hand");
            }
        }
    }
}
