using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double[] Shapearea=new double[10];
            double shapeareasun=0;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 10; i++)
            {
                Shape ob=ShapeFactory.shapecreate();
                Shapearea[i]=ob.Area;
                Console.WriteLine($"{ob.GetType().Name}:{Shapearea[i]}"); //输出各形状名与其面积；
                shapeareasun+=Shapearea[i];
            }
            Console.WriteLine("allshapesum:"+shapeareasun);
        }
    }
    public interface Shape{
        double Area{get;}
    }

    public class  Rectangle:Shape{
        private double length;
        private double width;
        public Rectangle(double l,double w){
            if(l<=0||w<=0) throw new ArgumentNullException("illegal!");
            length=l;
            width=w;
        }
        public double Length{
            get=>length;
            set{if(value<=0) throw new ArgumentNullException("illegal!");
                    else length=value;
            }
        }
        public double Width{
            get=>width;
            set{if(value<=0) throw new ArgumentNullException("illegal!");
                    else width=value;
            }
        }
        public double Area{
            get=>length*width;
        } 
    }

    public class  Square:Rectangle{
        public Square(double l):base(l,l){}
        new public double Width{
            get=>this.Length;
        }
        new public double Area{
            get=>this.Length*this.Length;
        } 
    }

    public class Triangle:Shape{
        private double side1;
        private double side2;
        private double side3;
        public Triangle(double s1,double s2,double s3){
            if(s1<=0||s2<=0||s3<=0||s1+s2<=s3||s1+s3<=s2||s3+s2<=s1) throw new ArgumentNullException("illegal!");
            side1=s1;
            side2=s2;
            side3=s3;
        }
        public double Side1{
            get=>side1;
            set{
                if(value<=0||value+side2<=side3||value+side3<=side2||side3+side2<=value) throw new ArgumentNullException("illegal!");
                side1=value;
            }
        }
        public double Side2{
            get=>side2;
            set{
                if(value<=0||value+side1<=side3||value+side3<=side1||side3+side1<=value) throw new ArgumentNullException("illegal!");
                side2=value;
            }
        }
        public double Side3{
            get=>side3;
            set{
                if(value<=0||value+side2<=side1||value+side1<=side2||side1+side2<=value) throw new ArgumentNullException("illegal!");
                side3=value;
            }
        }
        public double Area{
            get{
                double p=(side1+side2+side3)/2;
                return Math.Sqrt(p*(p-side1)*(p-side2)*(p-side3));
            }
        } 
    }

    public class ShapeFactory{//随机创建一个形状的工厂；
        public static Shape shapecreate(){
            Random d = new Random(Guid.NewGuid().GetHashCode());
            Shape sh=null;
            bool successful =false;
            while(!successful){
                successful=true;
                try
                {
                    switch (d.Next(3))
                    {//形状随机，各边长随机为10以下的浮点数；
                        case 0:sh=new Rectangle(d.NextDouble()*10,d.NextDouble()*10);break;
                        case 1:sh=new Square(d.NextDouble()*10);break;
                        case 2:sh=new Triangle(d.NextDouble()*10,d.NextDouble()*10,d.NextDouble()*10);break;
                        default:break;
                    }
                }
                catch (ArgumentNullException e)
                {
                    successful=false;//若创造的形状不合法，则创建失败；
                }
            }
            return sh;
        }
    }
}
