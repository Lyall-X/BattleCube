using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UImain : MonoBehaviour{

//	Button	button; 
	Image imageL;
	Image imageR;
	Image quit;
	Image spend200GLive;
	Image gameoverSeeAd;
	Image SeeAdGet23G;
	Image btLoadlostMenu;
	GameObject btSet;
	GameObject myAd;
	GameObject btSkill;

	public Text CountMeter;
	public Text cointText;
	public Text SkillTimeText;
	public Text ShieldTimeText;
	public Text SwordTimeText;
	public Text CountDonwText;
	public Text AgainCountDonwText;



	public static UImain instance;


	public GameObject[]		UIGo;

	void Start () 
	{
		instance = this;
		imageL 				= GameObject.Find("ButtonL").GetComponent<Image>();
		imageR 				= GameObject.Find("ButtonR").GetComponent<Image>();	
		quit   				= GameObject.Find("ButtonQ").GetComponent<Image>();	
		spend200GLive 		= GameObject.Find("btSpendCoinLive").GetComponent<Image>();	
		gameoverSeeAd 		= GameObject.Find("gameoverSeeAd").GetComponent<Image>();	
		SeeAdGet23G 		= GameObject.Find("SeeAdGet23G").GetComponent<Image>();	
		btLoadlostMenu		= GameObject.Find("btLoadlostMenu").GetComponent<Image>();		
		btSet 				= GameObject.Find ("btSet");
		myAd				= GameObject.Find ("myAD");
		btSkill				= GameObject.Find ("btSkill");
		EventTriggerListener.Get(imageL.gameObject).onDown  			= OnButtonClick;
		EventTriggerListener.Get(imageR.gameObject).onClick 			= OnButtonClick;
		EventTriggerListener.Get(quit.gameObject).onClick   			= OnButtonClick;
		EventTriggerListener.Get(spend200GLive.gameObject).onClick   	= OnButtonClick;
		EventTriggerListener.Get(gameoverSeeAd.gameObject).onClick   	= OnButtonClick;
		EventTriggerListener.Get(SeeAdGet23G.gameObject).onClick   		= OnButtonClick;
		EventTriggerListener.Get(btLoadlostMenu.gameObject).onClick   	= OnButtonClick;
		EventTriggerListener.Get(btSet).onClick   						= OnButtonClick;
		EventTriggerListener.Get(btSkill).onClick   					= OnButtonClick;

		CountMeter		 	= GameObject.Find("CountMeter").GetComponent<Text>();
		cointText  		 	= GameObject.Find("Coin").GetComponent<Text>();
		CountDonwText    	= GameObject.Find("countdownText").GetComponent<Text>();
		AgainCountDonwText  = GameObject.Find("deadCount").GetComponent<Text>();

		CountMeter.text 	="0";
		cointText.text  	="0";
		CountDonwText.text	="0";


		activeUI (0, false);
		activeUI (1, false);

	} 

	private void OnButtonClick(GameObject go){
		
		if(go == imageL.gameObject)
		{

			heroContrl.instance.isLeft = true;
			heroContrl.instance.isRight = false;
			heroContrl.instance.forward = false;
			heroContrl.instance.sMove = false;		
		}
		if(go == imageR.gameObject)
		{
			
			heroContrl.instance.isRight = true;
			heroContrl.instance.isLeft = false;
			heroContrl.instance.sMove = false;
			heroContrl.instance.forward = false;
		}
		if(go == quit.gameObject){
			
			Application.LoadLevel("start");
		}
		if(go == spend200GLive.gameObject){

			GameManger.instace.spend200Glive ();
		}
		if(go == btLoadlostMenu.gameObject){
			UImain.instance.activeUI (0, false);
			UImain.instance.activeUI (1, true);
			GameManger.instace.StopAllCroti ();
		}
		if(go == btSet){

			Application.LoadLevel ("start");
		}
		if(go == btSkill){
			heroContrl.instance.useSkill ();
			go.gameObject.SetActive (false);
			GameManger.instace.playSound (11);
		
			spawnObject.instance.CreatFx ("skillExplosion", GameManger.instace.GetTouchPosion ());
		}
		if(go ==SeeAdGet23G.gameObject ){

			Debug.Log ("here to set you ad");
			//if see ad 
			//save.instance.Save(23,"coin")
		}
		if(go ==gameoverSeeAd.gameObject ){

			Debug.Log ("here to set you ad");
			//if see ad 
			//GameManger.instace.seeAdReset();
		}

	}


	public void activeUI(int id,bool isActive)
	{		
		if(isActive)
		{
			UIGo [id].SetActive (true);
		}
		else
		{
			UIGo [id].SetActive (false);
		}
	}
#if _DEBUG
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
			heroContrl.instance.isLeft = true;
			heroContrl.instance.isRight = false;
			heroContrl.instance.forward = false;
			heroContrl.instance.sMove = false;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			heroContrl.instance.isRight = true;
			heroContrl.instance.isLeft = false;
			heroContrl.instance.sMove = false;
			heroContrl.instance.forward = false;
		}
    }
#endif


}
