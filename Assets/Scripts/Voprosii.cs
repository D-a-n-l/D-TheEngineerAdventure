using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
 
public class Voprosii : MonoBehaviour {
    [System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];

}   

    public Sprite[] TFIcons = new Sprite[2];

    public Image TFIcon;
    public GameObject button;
    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;

    public Button[] answerBttns = new Button[3];
    QuestionList crntQ;
    List<object> qList;
    int randQ;
    
    void OnTriggerEnter2D()
    {
        button.SetActive(true);
        Time.timeScale = 0f;
        qList = new List<object>(questions);
        questionGenerate();
    }
    void OnTriggerExit2D()
    {
        button.SetActive(false);
    }   
        void questionGenerate()
        {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
            StartCoroutine(animBttns());
        }
        else
        {
            print("Вы прошли игру");
        }
    }
    IEnumerator animBttns()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        int a = 0;
        while (a < answerBttns.Length)
        {
            if (!answerBttns[a].gameObject.activeSelf) answerBttns[a].gameObject.SetActive(true);

            a++;
            yield return new WaitForSeconds(1);
        }
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
        yield break;
    }
        IEnumerator trueOrFalse(bool check)
    {
        if (check)
        {
                        yield return new WaitForSeconds(3);
            TFIcon.sprite = TFIcons[1];
            yield return new WaitForSeconds(3);
                    button.SetActive(false);
        Time.timeScale = 1f;
        }
        else
        {
                        yield return new WaitForSeconds(3);
            TFIcon.sprite = TFIcons[0];
            yield return new WaitForSeconds(3);
                                button.SetActive(false);
        Time.timeScale = 1f;
        }
    }
    
        public void AnswerBttns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) {
            StartCoroutine(trueOrFalse(true));
                                            button.SetActive(false);
        Time.timeScale = 1f;
                    Textt.key += 1;
                                Destroy(gameObject);
            }
        else {
            StartCoroutine(trueOrFalse(false));
                                            button.SetActive(false);
        Time.timeScale = 1f;
                    Textt.key -= 1;
                                Destroy(gameObject);
            };
    }
}
