using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib
{
    /// <summary>
    /// An abstract class that represents a Scene in a Game.
    /// </summary>
    public abstract class Scene : IInitializeable, IUpdateable
    {
        #region Constructors

        public Scene()
        {
            IsSceneOver = false;
        }

        #endregion



        #region Public Delegates/Events

        public delegate void OnSomethingChanged(Scene sender);


        /// <summary>
        /// An event that occurs when the scene ends.
        /// </summary>
        public event OnSomethingChanged OnSceneEnded;


        /// <summary>
        /// An event that occurs when the scene has started.
        /// </summary>
        public event OnSomethingChanged OnSceneStarted;


        /// <summary>
        /// An event that occurs when the scene is updated.
        /// </summary>
        public event OnSomethingChanged OnSceneUpdated;


        /// <summary>
        /// An event that occurs when the scene will restart.
        /// </summary>
        public event OnSomethingChanged OnSceneRestarted;


        #endregion



        #region Instance Variables

        /// <summary>
        /// A boolean flag to tell whether the game is over.
        /// </summary>
        public bool IsSceneOver
        {
            get { return isSceneOver; }
            set
            {
                isSceneOver = value;
                if (IsSceneOver)
                {
                    // notify the world that the game ended.
                    if (OnSceneEnded != null) 
                        OnSceneEnded(this);
                }
            }
        }
        private bool isSceneOver;

        #endregion


        
        #region Public Methods

        /// <summary>
        /// Restarts the Scene.
        /// </summary>
        public void Restart()
        {
            Initialize();

            if (OnSceneRestarted != null)
            {
                OnSceneRestarted(this);
            }
        }


        /// <summary>
        /// Ends the Scene.
        /// </summary>
        public void End()
        {
            IsSceneOver = true;
        }

        #endregion



        #region Overrideable Methods

        /// <summary>
        /// Starts the Game off.
        /// </summary>
        public virtual void Initialize()
        {
            IsSceneOver = false;
            // notify the world that the game started
            if (OnSceneStarted != null)
            {
                OnSceneStarted(this);
            }
        }


        /// <summary>
        /// Updates the Game.
        /// </summary>
        public virtual void Update()
        {
            // notify the world that the game has been updated
            if (OnSceneUpdated != null)
            {
                OnSceneUpdated(this);
            }
        }

        #endregion
    }
}