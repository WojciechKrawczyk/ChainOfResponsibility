using System.Text;

namespace PictureProduction
{
    interface IMachine
    {
        // you can add required methods here
        void Handle(Order order, IPicture picture);

        IMachine SetNextMachine(IMachine machine);
    }

    class ProductionLine: IMachine
    {
        IMachine nextMachine;

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }

        public void Handle(Order order, IPicture picture)
        {
            if (ValidOrder(order))
                nextMachine.Handle(order, picture);
            else
                System.Console.WriteLine("Error: Invalid order!");
        }

        static bool ValidString(string s)
        {
            if (s == null)
                return false;
            if (s.Length == 0)
                return false;
            string ss = s.ToLower();
            char[] chars = ss.ToCharArray();
            foreach (char c in chars)
            {
                if (c < 97 || c > 122)
                    return false;
            }
            return true;
        }

        static bool ValidOrder(Order order)
        {
            if (ValidString(order.Color) == false || ValidString(order.Operation) == false || ValidString(order.Shape) == false || ValidString(order.Text) == false)
                return false;
            return true;
        }
    }

    //ColorMachines 
    class RedColorMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Color == "red")
                pic.Color = order.Color;
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class GreenColorMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Color == "green")
                pic.Color = order.Color;
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class BlueColorMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Color == "blue")
                pic.Color = order.Color;
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class FinalColorMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (pic.Color == null)
                pic.Color = string.Empty;
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    //TextMachines
    class SpacingTextMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Operation == "spacing")
            {
                char[] chars = order.Text.ToCharArray();
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < chars.Length - 1; i++)
                    stringBuilder.Append(chars[i]).Append(" ");
                stringBuilder.Append(chars[chars.Length - 1]);
                pic.Text = stringBuilder.ToString();
            }
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class UppercaseTextMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Operation == "uppercase")
                pic.Text = order.Text.ToUpper();
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class FinalTextMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (pic.Text == null)
                pic.Text = order.Text;
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    //FrameMachines
    class SimpleCircleFrameMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Shape == "circle")
            {
                pic.LeftFrame = "((";
                pic.RightFrame = "))";
            }
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class SimpleSquareFrameMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Shape == "square")
            {
                pic.LeftFrame = "[[";
                pic.RightFrame = "]]";
            }
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class ComplexCircleFrameMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Shape == "circle" && pic.Color == string.Empty && order.Operation == "spacing")
            {
                pic.LeftFrame = "(((";
                pic.RightFrame = ")))";
            }
            else if (order.Shape == "circle" && (pic.Color == string.Empty || order.Operation == "spacing"))
            {
                pic.LeftFrame = "((";
                pic.RightFrame = "))";
            }
            else if(order.Shape == "circle")
            {
                pic.LeftFrame = "(";
                pic.RightFrame = ")";
            }
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class ComplexSquareFrameMachine : IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Shape == "square" && pic.Color == string.Empty && order.Operation == "spacing")
            {
                pic.LeftFrame = "[[[";
                pic.RightFrame = "]]]";
            }
            else if (order.Shape == "square" && (pic.Color == string.Empty || order.Operation == "spacing"))
            {
                pic.LeftFrame = "[[";
                pic.RightFrame = "]]";
            }
            else if (order.Shape == "square")
            {
                pic.LeftFrame = "[";
                pic.RightFrame = "]";
            }
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class ComplexTriangleFrameMachine : IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (order.Shape == "triangle" && pic.Color == string.Empty && order.Operation == "spacing")
            {
                pic.LeftFrame = "<<<";
                pic.RightFrame = ">>>";
            }
            else if (order.Shape == "triangle" && (pic.Color == string.Empty || order.Operation == "spacing"))
            {
                pic.LeftFrame = "<<";
                pic.RightFrame = ">>";
            }
            else if (order.Shape == "triangle")
            {
                pic.LeftFrame = "<";
                pic.RightFrame = ">";
            }
            nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class FinalCheckFrameMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            Picture pic = new Picture(picture);
            if (pic.LeftFrame == null)
                System.Console.WriteLine("Error: Cannot create picture!");
            else
                nextMachine.Handle(order, pic);
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }

    class PresentationMachine: IMachine
    {
        IMachine nextMachine;

        public void Handle(Order order, IPicture picture)
        {
            picture.Print();
        }

        public IMachine SetNextMachine(IMachine machine)
        {
            this.nextMachine = machine;
            return machine;
        }
    }
}
