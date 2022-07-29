#if UNITY_EDITOR
using GameElements.Unity;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameElements.UnityEditor
{
    [CustomEditor(typeof(MonoGameSystem))]
    public sealed class MonoGameSystemEditor : Editor
    {
        private MonoGameSystem gameSystem;

        private SerializedProperty autoRun;

        private SerializedProperty gameServices;

        private SerializedProperty gameElements;

        private DragAndDropDrawler dragAndDropServiceDrawler;

        private DragAndDropDrawler dragAndDropElementDrawler;

        private void OnEnable()
        {
            this.gameSystem = (MonoGameSystem) this.target;

            this.autoRun = this.serializedObject.FindProperty(nameof(this.autoRun));
            this.gameServices = this.serializedObject.FindProperty(nameof(this.gameServices));
            this.gameElements = this.serializedObject.FindProperty(nameof(this.gameElements));

            this.dragAndDropServiceDrawler = new DragAndDropServiceDrawler();
            this.dragAndDropServiceDrawler.OnDragAndDrop += this.OnDragAndDropService;

            this.dragAndDropElementDrawler = new DragAndDropElementDrawler();
            this.dragAndDropElementDrawler.OnDragAndDrop += this.OnDragAndDropElement;
        }

        private void OnDisable()
        {
            this.dragAndDropServiceDrawler.OnDragAndDrop -= this.OnDragAndDropService;
            this.dragAndDropElementDrawler.OnDragAndDrop -= this.OnDragAndDropElement;
        }

        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            EditorGUILayout.Space(2);
            EditorGUILayout.PropertyField(this.autoRun);
            EditorGUILayout.Space(2);

            GUI.enabled = false;
            EditorGUILayout.LabelField($"Status:  {this.gameSystem.State}");
            GUI.enabled = true;

            EditorGUILayout.Space(2);
            this.DrawGameServices();
            EditorGUILayout.Space(10);
            this.DrawGameElements();

            this.serializedObject.ApplyModifiedProperties();
        }

        private void DrawGameServices()
        {
            EditorGUILayout.PropertyField(this.gameServices, includeChildren: true);
            EditorGUILayout.Space(8);
            this.dragAndDropServiceDrawler.Draw();
        }

        private void DrawGameElements()
        {
            EditorGUILayout.PropertyField(this.gameElements, includeChildren: true);
            EditorGUILayout.Space(8);
            this.dragAndDropElementDrawler.Draw();
        }

        private void OnDragAndDropElement(Object draggedObject)
        {
            if (draggedObject is GameObject gameObject)
            {
                this.AddElementByGameObject(gameObject);
                EditorUtility.SetDirty(this.gameSystem);
            }

            if (draggedObject is IGameElement gameElement)
            {
                this.gameSystem.Editor_AddElement(gameElement);
                EditorUtility.SetDirty(this.gameSystem);
            }
        }

        private void AddElementByGameObject(GameObject gameObject)
        {
            var gameElements = gameObject.GetComponents<IGameElement>();
            foreach (var element in gameElements)
            {
                this.gameSystem.Editor_AddElement(element);
            }
        }

        private void OnDragAndDropService(Object draggedObject)
        {
            if (draggedObject is GameObject gameObject)
            {
                this.AddServiceByGameObject(gameObject);
                EditorUtility.SetDirty(this.gameSystem);
            }

            if (draggedObject is MonoBehaviour monoBehaviour)
            {
                this.AddServiceByMonoBehavour(monoBehaviour);
                EditorUtility.SetDirty(this.gameSystem);
            }
        }

        private void AddServiceByMonoBehavour(MonoBehaviour monoBehaviour)
        {
            if (monoBehaviour is IGameElementGroup)
            {
                return;
            }

            this.gameSystem.Editor_AddService(monoBehaviour);
        }

        private void AddServiceByGameObject(GameObject gameObject)
        {
            var monoBehaviours = gameObject.GetComponents<MonoBehaviour>();
            foreach (var monoBehaviour in monoBehaviours)
            {
                this.AddServiceByMonoBehavour(monoBehaviour);
            }
        }
    }
}
#endif