using System;
using System.Collections.Generic;

namespace PictureProduction
{
    class Program
    {
        private readonly static Order[] orders =
        {
            new Order("circle", "red", "Hello", "spacing"),
            new Order("square", "green", "HelloWorld", "spacing"),
            new Order("triangle", "blue", "ChainIsBeauty", "spacing"),

            new Order("circle", "red", "Hello", "uppercase"),
            new Order("square", "green", "HelloWorld", "uppercase"),
            new Order("triangle", "blue", "ChainIsBeauty", "uppercase"),

            new Order("circle", "red", "Hello", "lowercase"),
            new Order("square", "yellow", "HelloWorld", "lowercase"),
            new Order("hash", "red", "ChainIsBeauty", "uppercase"),

            new Order("", "green", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "1234", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "green", null, "uppercase"), //invalid order
        };
        
        static void ProducePictures(IEnumerable<Order> orders, ProductionLine productionLine)
        {
            foreach(var o in orders)
            {
                Picture picture = new Picture();
                productionLine.Handle(o, picture);
            }
        }

        static void Main(string[] args)
        {
            //color
            RedColorMachine red = new RedColorMachine();
            GreenColorMachine green = new GreenColorMachine();
            BlueColorMachine blue = new BlueColorMachine();
            FinalColorMachine finalColor = new FinalColorMachine();

            //text
            UppercaseTextMachine uppercase = new UppercaseTextMachine();
            SpacingTextMachine spacing = new SpacingTextMachine();
            FinalTextMachine finalText = new FinalTextMachine();

            //frame
            FinalCheckFrameMachine finalFrame = new FinalCheckFrameMachine();

            //presentation
            PresentationMachine presentation = new PresentationMachine();

            Console.WriteLine("--- Simple Production Line ---");
            ProductionLine simple = new ProductionLine();
            //Machine special for simple line
            SimpleCircleFrameMachine simpleCircle = new SimpleCircleFrameMachine();
            SimpleSquareFrameMachine simpleSquare = new SimpleSquareFrameMachine();

            simple.SetNextMachine(red).SetNextMachine(finalText).SetNextMachine(simpleCircle).SetNextMachine(simpleSquare).SetNextMachine(finalFrame).SetNextMachine(presentation);

            ProducePictures(orders, simple);

            Console.WriteLine();

            Console.WriteLine("--- Complex Production Line ---");
            ProductionLine complex = new ProductionLine();
            //Machine special for complex line
            ComplexCircleFrameMachine complexCircle = new ComplexCircleFrameMachine();
            ComplexSquareFrameMachine complexSquare = new ComplexSquareFrameMachine();
            ComplexTriangleFrameMachine complexTriangle = new ComplexTriangleFrameMachine();

            complex.SetNextMachine(red).SetNextMachine(green).SetNextMachine(blue).SetNextMachine(finalColor).
                    SetNextMachine(spacing).SetNextMachine(uppercase).SetNextMachine(finalText).
                    SetNextMachine(complexCircle).SetNextMachine(complexSquare).SetNextMachine(complexTriangle).SetNextMachine(finalFrame).
                    SetNextMachine(presentation);

            ProducePictures(orders, complex);
        }
    }
}
