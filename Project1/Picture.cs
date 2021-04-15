using System;
using System.Text;

namespace PictureProduction
{
    interface IPicture
    {
        string LeftFrame { get; }
        string RightFrame { get;  }
        string Color { get; }
        string Text { get;  }

        void Print();
    }

    class Picture: IPicture
    {
        private string color;
        private string leftFrame;
        private string rightFrame;
        private string text;

        public Picture() { }

        public Picture(IPicture picture)
        {
            this.Color = picture.Color;
            this.LeftFrame = picture.LeftFrame;
            this.RightFrame = picture.RightFrame;
            this.Text = picture.Text;
        }

        public string LeftFrame
        {
            get { return this.leftFrame; }
            set { leftFrame = value; }
        }

        public string RightFrame
        {
            get { return this.rightFrame; }
            set { rightFrame = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { color = value; }
        }

        public string Text
        {
            get { return this.text; }
            set { text = value; }
        }

        public void Print()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(LeftFrame).Append(Color).Append(RightFrame).Append(" ").Append(Text).Append(" ").Append(LeftFrame).Append(Color).Append(RightFrame);
            System.Console.WriteLine($"{stringBuilder}");
        }
    }
}
