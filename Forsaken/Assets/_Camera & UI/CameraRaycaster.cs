using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

using RPG.Personagem; // detecta o tipo



namespace RPG.CameraUI
{
    public class CameraRaycaster : MonoBehaviour
    {


        [SerializeField] Texture2D walkCursor = null;
        [SerializeField] Texture2D enemyCursor = null;
        [SerializeField] Texture2D npcCursor = null;
        [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

        const int POTENTIALYWALKABLE = 8;
        float maxRaycastDepth = 100f; // Hard coded value
        Rect currentScreenRect; // evita que o raycast va para fora da tela

     

     
        public delegate void OnMouseOverEnemy(EnemyAI enemy);
        public event OnMouseOverEnemy onMouseOverEnemy ;

        public delegate void OnMouseOverNPC(NpcAI npc);
        public event OnMouseOverNPC onMouseOverNPC;

        public delegate void OnMouseOverTerrain(Vector3 destination);
        public event OnMouseOverTerrain onMouseOverPotentiallyWalkable; 

        void Update()
        {
            currentScreenRect = new Rect(0, 0, Screen.width, Screen.height);
            // Check if pointer is over an interactable UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {

                //Implementar UI
                //NotifyObserersIfLayerChanged(5);
            } else
            {
                PerformRaycast();
            }

        }
        void PerformRaycast() {
            if (currentScreenRect.Contains(Input.mousePosition)) { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // especificar layer priorities
            if (RaycastForEnemy(ray)){ return; }
            if (RaycastForNPC(ray)) { return; }
            if (RaycastForWalkable(ray)) { return; }
            
            }

        }

        bool RaycastForEnemy(Ray ray)
        {
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo, maxRaycastDepth);
            var gameObjectHit = hitInfo.collider.gameObject;
            var enemyHit = gameObjectHit.GetComponent<EnemyAI>();
            if (enemyHit) {
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                onMouseOverEnemy(enemyHit);
                return true;
            }
            return false;
        }

        bool RaycastForNPC(Ray ray)
        {
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo, maxRaycastDepth);
            var gameObjectHit = hitInfo.collider.gameObject;
            var npcHit = gameObjectHit.GetComponent<NpcAI>();
            if(npcHit)
            {
                Cursor.SetCursor(npcCursor, cursorHotspot, CursorMode.Auto);
                onMouseOverNPC(npcHit);
                return true;
            }
            return false;
        }

        private bool RaycastForWalkable(Ray ray)
        {
            RaycastHit hitInfo;
            LayerMask walkableLayer = 1 << POTENTIALYWALKABLE;
            bool potentialWalkableHit = Physics.Raycast(ray, out hitInfo, maxRaycastDepth, walkableLayer);
            if (potentialWalkableHit) {
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                onMouseOverPotentiallyWalkable(hitInfo.point);
                return true;
            }

            return false;
        }


 
    }
}