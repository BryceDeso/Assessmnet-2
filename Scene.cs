﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace HelloWorld
{
    class Scene
    {
        private Actor[] _actors;
        private Matrix3 _transform = new Matrix3();

        public bool Started { get; private set; }

        public Matrix3 World
        {
            get { return _transform; }
        }

        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            Actor[] appendedArray = new Actor[_actors.Length + 1];

            for (int i = 0; i < _actors.Length; i++)
            {
                appendedArray[i] = _actors[i];
            }

            appendedArray[_actors.Length] = actor;

            _actors = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            if (index < 0 || index >= _actors.Length)
            {
                return false;
            }

            bool actorRemoved = false;

            Actor[] newArray = new Actor[_actors.Length - 1];

            int j = 0;

            for (int i = 0; i < _actors.Length; i++)
            {
                if (i != index)
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (_actors[i].Started)
                        _actors[i].End();
                }
            }

            _actors = newArray;
            return actorRemoved;
        }

        private void CheckCollision()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                for (int j = 0; i < _actors.Length; j++)
                {
                    if (_actors[i].CheckCollision(_actors[j]) && i != j)
                    {
                        _actors[i].OnCollision(_actors[j]);
                    }

                    if (i > -_actors.Length)
                    {
                        break;
                    }                 
                }
            }
        }

        public bool RemoveActor(Actor actor)
        {
            //Check to see if the actor was null
            if (actor == null)
            {
                return false;
            }

            bool actorRemoved = false;

            Actor[] newArray = new Actor[_actors.Length - 1];

            int j = 0;

            for (int i = 0; i < _actors.Length; i++)
            {
                if (actor != _actors[i])
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (actor.Started)
                        actor.End();
                }
            }

            _actors = newArray;

            return actorRemoved;
        }

        public virtual void Start()
        {

        }

        public virtual void Update(float deltaTime)
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Update(deltaTime);
            }
            CheckCollision();
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public virtual void End()
        {

        }
    }
}
