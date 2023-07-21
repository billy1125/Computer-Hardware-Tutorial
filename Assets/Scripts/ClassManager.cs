using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using cakeslice;

[System.Serializable]
public class Contents
{
    public string Title;
    [TextArea]
    public string SubtitleText;
    public AudioClip TextContentAudioclips;
    public GameObject HintModel;
    public GameObject MatchModel;
    public string MatchModelTag;
    public Vector3 MatchVector3;
    public Vector3 MatchLoVector3;
}

public class ClassManager : Singleton<ClassManager>
{
    public List<Contents> contents = new List<Contents>();

    public GameObject Player;
    public GameObject Camera;
    public GameObject BeforeComputer;
    public GameObject Computer;

    public Text TitleText;
    public Text HintText;

    public int ContentNumber;

    public string SelectModelName;
    public string CheckModelName;

    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        ContentNumber = 0;
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ContentNumber < contents.Count) {
            contents[ContentNumber].MatchModel.SetActive(true);

            TitleText.text = contents[ContentNumber].SubtitleText;
         
            if (contents[ContentNumber].HintModel.GetComponent<cakeslice.Outline>().eraseRenderer == true)
                contents[ContentNumber].HintModel.GetComponent<cakeslice.Outline>().eraseRenderer = false;

            if (contents[ContentNumber].MatchModelTag == CheckModelName)
            {
                contents[ContentNumber].MatchModel.transform.position = Vector3.Lerp(contents[ContentNumber].MatchModel.transform.position, contents[ContentNumber].MatchVector3, Time.deltaTime);
                contents[ContentNumber].MatchModel.transform.rotation = Quaternion.Lerp(contents[ContentNumber].MatchModel.transform.rotation, Quaternion.Euler(contents[ContentNumber].MatchLoVector3), Time.deltaTime);

                if (Vector3.Distance(contents[ContentNumber].MatchModel.transform.position, contents[ContentNumber].MatchVector3) < 0.008)
                {
                    contents[ContentNumber].MatchModel.transform.position = contents[ContentNumber].MatchVector3;
                    contents[ContentNumber].MatchModel.transform.rotation = Quaternion.Euler(contents[ContentNumber].MatchLoVector3);
                    contents[ContentNumber].HintModel.GetComponent<cakeslice.Outline>().eraseRenderer = true;
                    contents[ContentNumber].MatchModel.GetComponent<cakeslice.Outline>().eraseRenderer = true;
                    AS.Play();
                    ContentNumber += 1;
                }
               
            }
        }
        //EndClass();
        if (ContentNumber == contents.Count)
            EndClass();
    }

    void EndClass()
    {
        Player.transform.position = new Vector3(0.5f, 1.16f, 1.25f);
        Camera.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        BeforeComputer.SetActive(false);
        Computer.SetActive(true);
        TitleText.text = "�{�b�A���ӥi�H��B�A�Ѥ@�x�q���p��w�ˡA���L�u�ꪺ�q���ո��٦���h�Ӹ`�A�p�G�A������A�������W���ܦh��T�ѧA��s�A�Ʊ�A�����q���ո˦��򥻪������@�I";
    }



    public void GoBacktoMain()
    {
        SceneManager.LoadScene("Main");
    }
}
