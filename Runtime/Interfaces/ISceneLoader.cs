/**
 * ISceneLoader.cs
 * Created by: João Borks [joao.borks@gmail.com]
 * Created on: 7/16/2022 (en-US)
 */

namespace MyUnityTools.SceneLoading
{
    /// <summary>
    /// Interface to standardize scene operations.
    /// </summary>
    public interface ISceneLoader
    {
        /// <summary>
        /// Triggers a scene transition.
        /// It will transition from the current active scene (<see cref="UnityEngine.SceneManagement.SceneManager.GetActiveScene()"/>)
        /// to the target scene (<paramref name="targetSceneInfo"/>), with an optional intermediate loading scene (<paramref name="intermediateSceneInfo"/>).
        /// If the <paramref name="intermediateSceneInfo"/> is not set, the transition will have no intermediate loading scene and will instead simply load the target scene directly.
        /// The complete transition flow is:
        /// <br/><br/>
        /// 1. Load the intermediate scene (if provided).<br/>
        /// 2. Load the target scene.<br/>
        /// 3. Unload the intermediate scene (if provided).<br/>
        /// 4. Unload the previous scene
        /// </summary>
        /// <param name="targetSceneInfo">
        /// The scene that's going to be transitioned to.
        /// Can be the scene's build index (<see cref="LoadSceneInfoIndex"/>) or name (<see cref="LoadSceneInfoName"/>).
        /// </param>
        /// <param name="intermediateSceneInfo">
        /// The scene that's going to be loaded as the transition intermediate (as a loading scene).
        /// Can be the scene's build index (<see cref="LoadSceneInfoIndex"/>) or name (<see cref="LoadSceneInfoName"/>).
        /// If null, the transition will not have an intermediate loading scene.
        /// </param>
        void TransitionToScene(ILoadSceneInfo targetSceneInfo, ILoadSceneInfo intermediateSceneInfo = null);

        /// <summary>
        /// Unloads the given scene from the current scene stack.
        /// </summary>
        /// <param name="sceneInfo">
        /// Target scene info.
        /// Can be the scene's build index (<see cref="LoadSceneInfoIndex"/>) or name (<see cref="LoadSceneInfoName"/>).
        /// </param>
        void UnloadScene(ILoadSceneInfo sceneInfo);

        /// <summary>
        /// Loads a scene additively on top of the current scene stack, optionally marking it as the active scene
        /// (<see cref="UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.Scene)"/>).
        /// </summary>
        /// <param name="sceneInfo">
        /// The scene that's going to be loaded.
        /// Can be the scene's build index (<see cref="LoadSceneInfoIndex"/>) or name (<see cref="LoadSceneInfoName"/>).
        /// </param>
        /// <param name="setActive">Should the loaded scene be marked as active? Equivalent to calling <see cref="UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.Scene)"/>.</param>
        void LoadScene(ILoadSceneInfo sceneInfo, bool setActive = false);
    }
}