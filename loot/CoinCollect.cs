using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public static int coinCount;
    private Text coinConter;
    // Start is called before the first frame update
    void Start()
    {
        coinConter = GetComponent<Text>();
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinConter.text = "X" + coinCount;
    }
}
