using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class ReadJson : MonoBehaviour {

    public static ReadJson instance;
    private JsonData itemDate;
    private string jsonString;
    [HideInInspector]
    public List<Information> myinformationList = new List<Information>();


    // Use this for initialization
    void Start () {
        Application.runInBackground = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (instance == null)
        {
            instance = this;
        }
        jsonString = Resources.Load<TextAsset>("information").text;
        //Debug.Log(jsonString);
        itemDate = JsonMapper.ToObject(jsonString);
        readjson();

        foreach (Information item in myinformationList)
        {
            item.sprite = item.ReadImage("Image/" + item.BigTitle);
           // Debug.Log(item.sprite);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void readjson()
    {

        //Debug.Log(itemDate["information"].Count);
        for (int i = 0; i < itemDate["information"].Count; i++)
        {
            int id = int.Parse(itemDate["information"][i]["id"].ToString());//get id; ;
            string bigTitle = itemDate["information"][i]["BigTitle"].ToString();//get bigtitle;;
            string mainContent = itemDate["information"][i]["MainContent"].ToString();
           // Debug.Log()
            myinformationList.Add(new Information(id, bigTitle, mainContent));
        }

        for (int i = 0; i < myinformationList.Count; i++)
        {
           // Debug.Log("ID: " + myinformationList[i].ID + "BigTitle: " + myinformationList[i].BigTitle + "MainContent: " + myinformationList[i].MainContent);

        }
    }

}
[System.Serializable]
public class Information : MonoBehaviour
{
    public int ID;
    public string BigTitle;
    public string MainContent;
    public Sprite sprite;


    public Information()
    {

    }

    public Information(int _id, string _bigTitle, string _mainContent)
    {
        ID = _id;
        BigTitle = _bigTitle;
        MainContent = _mainContent;


    }


    //"Image/" + BigTitle
    public Sprite ReadImage(string path)
    {
        // Debug.Log(path);
        Sprite temp = Resources.Load<Sprite>(path);
        //Debug.Log(temp);
        return temp;
    }
}
