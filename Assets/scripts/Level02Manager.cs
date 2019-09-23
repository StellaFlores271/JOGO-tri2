using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Level02Manager : MonoBehaviour
{
    public static Level02Manager instance = null;
    [SerializeField]
    private Vector3 TapeSpeed = new Vector3 (-2f, 0f, 0f);
    [SerializeField]
    private Transform Tape = null;

    [SerializeField]
    public GameObject joystick;

    public Level02UIComponents uicomponents;
    Level02SceneData sceneData = new Level02SceneData();
    void Awake()
    {
        Assert.IsNotNull(Tape);
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    public void DestroyJoystick() {
        Destroy(joystick);
    }


    // Update is called once per frame
    void Update()
    {
        Tape.position = Tape.position + TapeSpeed * Time.deltaTime;
        DisplayHudData();
    }
    public void IncrementCoinCount(){
        sceneData.coinCount++;
    }
    public void DecrementLifeCount(){
        sceneData.lifeCount--;
    }    
    public int GetLifeCount() {
        return sceneData.lifeCount;
    }
    void DisplayHudData(){
        uicomponents.hud.txtCoinCount.text = "x " + sceneData.coinCount;
        uicomponents.hud.txtLifeCount.text = "x " + sceneData.lifeCount;
    }
    public void SetTapeSpeed(float value){
        TapeSpeed = new Vector3(value, TapeSpeed.y, TapeSpeed.z);
    }
    public void ShowLevelComplete(){
        uicomponents.levelcompletepanel.LCpanel.SetActive(true);
        uicomponents.levelcompletepanel.txtScore.text = "" + sceneData.coinCount;
    }
    public void ShowGameOverPanel(){
        uicomponents.gameoverpanel.GOpanel.SetActive(true);
        uicomponents.gameoverpanel.txtScore.text = "" + sceneData.coinCount;
    }
}
