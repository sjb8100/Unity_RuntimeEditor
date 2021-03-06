﻿using UnityEngine;

using Battlehub.RTCommon;

namespace Battlehub.RTHandles
{
    /// <summary>
    /// Draws bounding box of selected object
    /// </summary>
    public class SelectionGizmo : MonoBehaviour, IGL
    {
        public bool DrawRay = true;
        public RuntimeHandlesComponent Appearance;
        private ExposeToEditor m_exposeToEditor;

        private RuntimeWindow m_window;
        public virtual RuntimeWindow Window
        {
            get { return m_window; }
            set { m_window = value; }
        }

        private IRTE m_editor;

        private void Awake()
        {
            m_editor = IOC.Resolve<IRTE>();
            m_exposeToEditor = GetComponent<ExposeToEditor>();
            RuntimeHandlesComponent.InitializeIfRequired(ref Appearance);
        }

        private void Start()
        {
            if (m_window == null)
            {
                m_window = m_editor.GetWindow(RuntimeWindowType.SceneView);
                if(m_window == null)
                {
                    Debug.LogError("m_window == null");
                    enabled = false;
                    return;
                }
            }

            if (GLRenderer.Instance == null)
            {
                GameObject glRenderer = new GameObject();
                glRenderer.name = "GLRenderer";
                glRenderer.AddComponent<GLRenderer>();
            }

            if (m_exposeToEditor != null)
            {
                GLRenderer.Instance.Add(this);
            }

            if (!m_exposeToEditor.Editor.Selection.IsSelected(gameObject))
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            if (m_exposeToEditor != null)
            {
                if (GLRenderer.Instance != null)
                {
                    GLRenderer.Instance.Add(this);
                }
            }
        }

        private void OnDisable()
        {
            if (GLRenderer.Instance != null)
            {
                GLRenderer.Instance.Remove(this);
            }
        }

        public void Draw(int cullingMask)
        {
            if (m_exposeToEditor.Editor.Tools.ShowSelectionGizmos)
            {
                if ((cullingMask & (1 << (m_editor.CameraLayerSettings.RuntimeGraphicsLayer + Window.Index))) == 0)
                {
                    return;
                }

                Bounds bounds = m_exposeToEditor.Bounds;
                Transform trform = m_exposeToEditor.BoundsObject.transform;
                Appearance.DrawBounds(ref bounds, trform.position, trform.rotation, trform.lossyScale);
            }
        }
    }
}
