using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Objectivs : MonoBehaviour {

    List<Objectiv> objectivs = new List<Objectiv>();


    List<Objectiv> has = new List<Objectiv>();

    public Text output;

    void Start()
    {
        objectivs.Add(new Objectiv("Find your sextape before its to late","tape"));
        objectivs.Add(new Objectiv("Find your playboy magazine before your wife", "mags"));
        objectivs.Add(new Objectiv("Find a key", "key"));
        objectivs.Add(new Objectiv("Find the exit", "exit"));

        outputObjctivs();
    }

    public bool hasItem(string keyword)
    {
        foreach(Objectiv o in has)
        {
            if (o.keyword == keyword)
                return true;
        }

        return true;
    }

    public void outputObjctivs()
    {

        string r = "";

        foreach(Objectiv o in objectivs)
        {
            string h = "- " + o.desc + "\n";

            r += h;
        }

        output.text = r;
    }

    int getObjectivIndex(string name)
    {
        if (objectivs.Count == 0)
            return -1;

        for(int i = 0; i < objectivs.Count-1; i++)
        {
            if (objectivs[i].keyword == name)
                return i;
        }

        return -1;
    }
	
    void addObjectiv(string objectiv,string keyword)
    {
        objectivs.Add(new Objectiv(objectiv,keyword));
    }

    public void RemoveObjectiv(string keyword)
    {
        int index = getObjectivIndex(keyword);

        if (index == -1)
            return;

        Debug.Log(objectivs[index].keyword);


        has.Add(new Objectiv(objectivs[index].desc, objectivs[index].keyword));
        objectivs.RemoveAt(index);


        outputObjctivs();

        if(GameObject.FindGameObjectWithTag("enemy") != null)
            GameObject.FindGameObjectWithTag("enemy").GetComponent<Crawler>().OnPickup();
    }
}


[System.Serializable]
public class Objectiv
{
    public string desc, keyword;


    public Objectiv(string _desc,string _keyword)
    {
        desc = _desc;
        keyword = _keyword;
    }
}
