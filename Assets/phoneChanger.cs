using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneChanger : MonoBehaviour
{
    public List<GameObject> phones;
    public List<Material> cases;
    public GameObject iPhoneCase;
    public List<GameObject> uiElems;
    public List<Material> samCases;
    public GameObject samsungCase;
    public List<GameObject> visibleCases;

    public Text iPhoneColorText;
    public Text samsungColorText;
    private List<string> iCaseColorTexts = new List<string>(new string[] {"Red Case", "Blue Case", "Black Case", ""});
    private List<string> sCaseColorTexts = new List<string>(new string[] {"Green Case", "Orange Case", "Pink Case", ""});

    public Text iPhoneCaseText;
    public Text samsungCaseText;

    public bool iPhone = true;

    public List<Material> phoneColorCases;

    public int counter = 0;

    private int currCase = -1;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        iPhoneCase.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SwitchPhones() {
        counter++;
        // 0-2 is iPhone, 3-4 is s10
        if (counter == 3 || counter == 5) {
            iPhone = !iPhone;
            phones[0].SetActive(!phones[0].activeSelf);
            phones[1].SetActive(!phones[1].activeSelf);
            uiElems[0].SetActive(!uiElems[0].activeSelf);
            uiElems[1].SetActive(!uiElems[1].activeSelf);
            if (currCase < 3 && currCase != -1) {
                visibleCases[0].SetActive(!visibleCases[0].activeSelf);
                visibleCases[1].SetActive(!visibleCases[1].activeSelf);
                samsungCaseText.text = sCaseColorTexts[currCase];
                iPhoneCaseText.text = iCaseColorTexts[currCase];
                iPhoneCase.GetComponent<MeshRenderer>().material = cases[currCase];  
                samsungCase.GetComponent<MeshRenderer>().material = samCases[currCase];              
            }
            if (counter == 5) {
                counter = 0;
            }
        }
        if (counter == 0) {
            iPhoneColorText.text = "Space Gray";
        }
        if (counter == 1) {
            iPhoneColorText.text = "Black";
        }
        if (counter == 2) {
            iPhoneColorText.text = "Rose Gold";
        }
        if (counter == 3) {
            samsungColorText.text = "Prism White";
        }
        if (counter == 4) {
            samsungColorText.text = "Prism Black";
        }
        phones[0].GetComponent<MeshRenderer>().material = phoneColorCases[counter];
        phones[1].GetComponent<MeshRenderer>().material = phoneColorCases[counter];

    }

    void SwitchCases() {
        if (iPhone) {
            currCase++;
            if (currCase > 3) {
                currCase = 0;
                iPhoneCase.GetComponent<MeshRenderer>().material = cases[currCase];
            }
            else if (currCase < 3) {
                iPhoneCase.transform.parent.gameObject.SetActive(true);
                iPhoneCase.GetComponent<MeshRenderer>().material = cases[currCase];
            }
            else if (currCase == 3) {
                iPhoneCase.transform.parent.gameObject.SetActive(!iPhoneCase.transform.parent.gameObject.activeSelf);
                currCase = -1;
            }
        }
        else {
            currCase++;
            if (currCase > 3) {
                currCase = 0;
                samsungCase.GetComponent<MeshRenderer>().material = samCases[currCase];
            }
            else if (currCase < 3) {
                samsungCase.transform.parent.gameObject.SetActive(true);
                samsungCase.GetComponent<MeshRenderer>().material = samCases[currCase];
            }
            else if (currCase == 3) {
                samsungCase.transform.parent.gameObject.SetActive(!samsungCase.transform.parent.gameObject.activeSelf);
                currCase = -1;
            }
        }
        if (currCase == -1) {
            samsungCaseText.text = sCaseColorTexts[3];
            iPhoneCaseText.text = iCaseColorTexts[3];
        }
        else {
            samsungCaseText.text = sCaseColorTexts[currCase];
            iPhoneCaseText.text = iCaseColorTexts[currCase];
        }
    }
}
