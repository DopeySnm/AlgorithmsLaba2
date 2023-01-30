using AlgorithmsLaba2.Model;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AlgorithmsLaba2
{
    class Tower
    {
        private string name;
        private StackPanel tower;
        private Stack<Ring> baseStack;
        public Tower(string name, StackPanel tower)
        {
            baseStack = new Stack<Ring>();
            this.name = name;
            this.tower = tower;
        }
        public StackPanel GetStackPanel()
        {
            return tower;
        }
        public void Push(Ring item)
        {
            baseStack.Push(item);
        }
        public void AddRing(Ring item)
        {
            tower.Children.Add(item.GetRect());
        }
        public void RemoveRing(Ring item)
        {
            tower.Children.Remove(item.GetRect());
        }
        public Ring Pop()
        {
            return baseStack.Pop();
        }
        public void Move(Tower from, Ring item)
        {
            tower.Children.Remove(item.GetRect());
            from.tower.Children.Add(item.GetRect());
        }
        public void Clear()
        {
            tower.Children.Clear();
            baseStack.Clear();
        }
        public override string ToString()
        {
            return this.name;
        }
    }
}
