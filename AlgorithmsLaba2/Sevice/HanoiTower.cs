using AlgorithmsLaba2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AlgorithmsLaba2.Sevice
{
    internal class HanoiTower
    {
        private int count;
        private Tower thisTower1;
        private Tower thisTower2;
        private Tower thisTower3;
        private StackPanel tower1;
        private StackPanel tower2;
        private StackPanel tower3;
        private TextBox inputRings;
        public HanoiTower(StackPanel stackPanel1, StackPanel stackPanel2, StackPanel stackPanel3, TextBox inputRings)
        {
            tower1 = stackPanel1;
            tower2 = stackPanel2;
            tower3 = stackPanel3;
            this.inputRings = inputRings;
            thisTower1 = new Tower("1", tower1);
            thisTower2 = new Tower("2", tower2);
            thisTower3 = new Tower("3", tower3);
        }
        private async Task TowerOfHanoi(int discs, Tower fromPeg, Tower toPeg, Tower otherPeg, int speed)
        {
            if (discs == 0)
            {
                return;
            }

            await TowerOfHanoi(discs - 1, fromPeg, otherPeg, toPeg, speed);

            Ring moveItem = fromPeg.Pop();
            fromPeg.RemoveRing(moveItem);

            toPeg.Push(moveItem);
            toPeg.AddRing(moveItem);

            await Task.Delay(speed);

            await TowerOfHanoi(discs - 1, otherPeg, toPeg, fromPeg, speed);
        }
        private bool ValidatingInput()
        {
            if (inputRings.Text == "")
            {
                return false;
            }
            var temp = inputRings.Text.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (!char.IsNumber(temp[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckFreeTowers()
        {
            var temp2 = thisTower2.GetStackPanel();
            var temp3 = thisTower3.GetStackPanel();
            if (temp2.Children.Count == 0 && temp3.Children.Count == 0)
            {
                return true;
            }
            return false;
        }
        public void ClearAllTowers()
        {
            thisTower1.Clear();
            thisTower2.Clear();
            thisTower3.Clear();
        }
        private int WidthCalculation(int count)
        {
            int size = 400 / count;
            return size;
        }
        private int HeightCalculation(int count)
        {
            int size = 800 / count;
            return size;
        }
        public void GetRings(string input)
        {
            if (ValidatingInput())
            {
                count = int.Parse(input);
                if (count == 0)
                {
                    return;
                }
                int width = WidthCalculation(count);
                int height = HeightCalculation(count);
                for (int i = count; i >= 1; i--)
                {
                    Ring ring = new Ring(i * width, height);
                    thisTower1.Push(ring);
                    thisTower1.AddRing(ring);
                }
            }
        }
        public void Start(int speed)
        {
            if (ValidatingInput() && tower1.Children.Count != 0 && CheckFreeTowers())
            {
                TowerOfHanoi(count, thisTower1, thisTower2, thisTower3, speed);
            }
            if (!CheckFreeTowers() && tower1.Children.Count == 0)
            {
                ClearAllTowers();
                GetRings(inputRings.Text);
            }
        }
    }
}
