using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Modules
{
    public class VR_ScreenManager : MonoBehaviour
    {
        public GameObject VR_Screen; //this is the content place holder game object
        PrefabManager prefabMgr;
        bool video360StartedPlaying = false;

        public static VR_ScreenManager instance;

        void Awake()
        {
            instance = this;
        }
        void Start()
        {
            prefabMgr = GetComponent<PrefabManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (video360StartedPlaying)
            {

            }
        }

        public static VR_ScreenManager getInstance()
        {
            return instance;
        }

        public void showTitle(UnitModule unit)
        {

            GameObject titlePage = prefabMgr.TitlePage;

            titlePage.transform.GetChild(0).GetComponent<TextMesh>().text = unit.unitcontent.title_info.title;

            titlePage.transform.GetChild(2).GetComponent<TextMesh>().text = "Unit " + unit.unit_number + ": " + unit.unitcontent.title_info.unit_info;

            titlePage.transform.GetChild(3).GetComponent<TextMesh>().text = unit.unitcontent.title_info.unit_desc;

            Instantiate(titlePage, VR_Screen.transform.position, Quaternion.identity, VR_Screen.transform);

        }

        public void showDialogMessage(string message)
        {
            removeContent();
            
            //this function must take care of the formatting and things ...
            GameObject infoDialog = prefabMgr.InfoBox;
            TextMesh infoText = infoDialog.transform.GetChild(0).GetComponent<TextMesh>();
            infoText.text = message;

            Instantiate(infoDialog, VR_Screen.transform.position, Quaternion.identity, VR_Screen.transform
                );
        }

        VideoPlayer vd;
        GameObject toplabel, vrboard, tableModel, walls;
        public void showMediaContent(MediaContent media)
        {
            if (media.type == "video360")
            {
                toplabel = GameObject.Find("Top_Label");
                vrboard = GameObject.Find("VR_Board");
                tableModel = GameObject.Find("Table_model");
                walls = GameObject.Find("walls");
                media360(media);
                return;
            }
            //play content here ...
            removeContent();
            
            string fileLocation = Application.streamingAssetsPath + "/" + media.file_source;

            GameObject videoBox = Instantiate(prefabMgr.VideoBox, VR_Screen.transform.position, Quaternion.identity, VR_Screen.transform) as GameObject;

            GameObject vdgameObject = GameObject.Find("VideoPlayer");
            vd = vdgameObject.GetComponent<VideoPlayer>();
            vd.url = fileLocation;
            vd.Play();

        }
        public void media360(MediaContent media)
        {
            hideAllObjects();
            string fileLocation = Application.streamingAssetsPath + "/" + media.file_source;
            GameObject video360Dome = GameObject.Find("Sphere");
            video360Dome.GetComponent<MeshRenderer>().enabled = true;

            GameObject vdgameObject = GameObject.Find("VideoPlayer");
            vd = vdgameObject.GetComponent<VideoPlayer>();
            vd.url = fileLocation;
            vd.Play();

            video360StartedPlaying = true;
            vd.loopPointReached += VideoEndReached;
        }


        public void hideAllObjects()
        {
            toplabel.SetActive(false);
            vrboard.SetActive(false);
            tableModel.SetActive(false);
            walls.SetActive(false);
           
        }

        void VideoEndReached(UnityEngine.Video.VideoPlayer vp)
        {
            toplabel.SetActive(true);
            vrboard.SetActive(true);
            tableModel.SetActive(true);
            walls.SetActive(true);

            GameObject video360Dome = GameObject.Find("Sphere");
            video360Dome.GetComponent<MeshRenderer>().enabled = false;
        }

        
        GameObject questionHolder;
        public void showMCQContent(Question question)
        {
            //show MCQ type on this page ...
            removeContent();

            

            //I will need a question creation engine ...
            GameObject questionPrefab = QuestionEngine.instance.createQuestionPrefab(question);

            questionPrefab.transform.position = VR_Screen.transform.position;
            questionPrefab.transform.SetParent(VR_Screen.transform);

            //GameObject questionInstance = Instantiate(questionPrefab, VR_Screen.transform.position, Quaternion.identity, VR_Screen.transform) as GameObject;

            //questionInstance.transform.SetParent(questionHolder.transform);

            questionPrefab.transform.Rotate(0f, -90f, 0f);

            GameObject questionBox = GameObject.Find("mc_question(Clone)");
            questionBox.transform.Translate(Vector3.up * 1f);


        }

        public void removeContent()
        {   
            //check if there's a video playing... stop the video ...
            if (vd != null)
            {
                vd.Stop();
            }

            foreach(Transform child in VR_Screen.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void publishContent(GameObject content)
        {

        }


    }

}
