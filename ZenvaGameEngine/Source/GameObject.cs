using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaGameEngine.Source
{
    abstract class GameObject
    {
        abstract public Vector2 Position { get; set; }
        abstract public Vector2 Origin { get; set; }
        abstract public Vector2 Scale { get; set; }
        abstract public string Tag { get; set; }
        abstract public List<GameObject> Children { get; set; }


        public GameObject()
        {
            Children = new List<GameObject>();
            Position = new Vector2();
            Origin = Position;
            Scale = new Vector2();
            Tag = "EmptyGameObject";

        }

        public virtual void AddChild(GameObject child)
        {
            Children.Add(child);
        }

        public virtual void FreeChild(GameObject child)
        {
            if(Children.Contains(child)) Children.Remove(child);
            
        }

        public virtual GameObject GetChild(string childTag)
        {
            foreach(GameObject child in Children)
            {
                if(childTag.Equals(child.Tag))
                {
                    return child;
                }
            }
            Log.Error($"GameObject {childTag} does not exist!");
            return null;
        }

        public virtual void FreeSelf()
        {


            if(Children == null) {  return; }
            foreach (GameObject child in Children)
            {
                child.FreeSelf();
            }


        }

        public virtual void UpdateChildren()
        {
            foreach(GameObject child in Children)
            {
                child.Position = Position + child
            }
        }

        abstract public void OnLoad();
        public abstract void OnUpdate();
        abstract public void OnFree();



    }
}
