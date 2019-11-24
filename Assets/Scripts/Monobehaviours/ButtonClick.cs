using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Modules;
using Runtime;


namespace Monobehaviours
{
    public class ButtonClick : MonoBehaviour
    {

        public void beginAdventure()
        {
            Main.instance.processNextUnitContent(Main.unit);
        }

        public void next()
        {
            Main.instance.processNextUnitContent(Main.unit);
        }

        public void previous()
        {
            Main.instance.processPreviousUnitContent(Main.unit);
        }

        public void refreshQuestion()
        {
            
            //Main.instance._VRScreenManager.showDialogMessage(Main.instance.quest)
            
            //Main.instance.
        }

        public Texture2D correctTexture, incorrectTexture;
        public void checkAnswer()
        {
            Renderer m_Renderer;
            m_Renderer = GetComponent<Renderer>();

            //get object ...
            if (gameObject.GetComponent<CustomObjectData>().possibleAnswer.state)
            {
                //then this answer is right 
                gameObject.GetComponent<MeshCollider>().enabled = false;
                m_Renderer.material.SetTexture("_MainTex", correctTexture);

                QuestionEngine.instance.questionDialog.GetComponentInChildren<TextMesh>().text = QuestionEngine.instance.CreatePanelText(gameObject.GetComponent<CustomObjectData>().possibleAnswer.reason);



            }
            else
            {
                //it;s wrong
                gameObject.GetComponent<MeshCollider>().enabled = false;
                m_Renderer.material.SetTexture("_MainTex", incorrectTexture);


                QuestionEngine.instance.questionDialog.GetComponentInChildren<TextMesh>().text = QuestionEngine.instance.CreatePanelText(gameObject.GetComponent<CustomObjectData>().possibleAnswer.reason);

            }

            //get data ...
        }


    }

}
