using System;

namespace test2
{
    public delegate void AlarmHandler(object sender,SetalarmEventArgs args);
    public class SetalarmEventArgs{//包含当前时间和设定响铃时间的属性集
        public int nowhour{get;set;}
        public int nowminute{get;set;}
        public int nowsecond{get;set;}
        public int ringhour{get;set;}
        public int ringminute{get;set;}
        public int ringsecond{get;set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Form form=new Form();
            int n1=Int32.Parse(Console.ReadLine());
            int n2=Int32.Parse(Console.ReadLine());
            int n3=Int32.Parse(Console.ReadLine());
            int r1=Int32.Parse(Console.ReadLine());
            int r2=Int32.Parse(Console.ReadLine());
            int r3=Int32.Parse(Console.ReadLine());
            form.alarmc.Settime(n1,n2,n3,r1,r2,r3);
            form.alarmc.Start();
        }
    }
    public class AlarmClock{
        public event AlarmHandler Ticktack;
        public event AlarmHandler Ring;
        static SetalarmEventArgs args = new SetalarmEventArgs();
        public void Settime(int nh,int nm,int ns,int rh,int rm,int rs){
            args.nowhour=nh;args.nowminute=nm;args.nowsecond=ns;args.ringhour=rh;args.ringminute=rm;args.ringsecond=rs;
            if(!(0<=nh&&nh<24&&0<=nm&&nm<60&&0<=ns&&ns<60&&0<=rh&&rh<24&&0<=rm&&rm<60&&0<=rs&&rs<60))throw new ArgumentNullException("Thetimeisillegal!");
            Console.WriteLine($"nowtime:{nh}:{nm}:{ns}");
            Console.WriteLine($"ringtime:{rh}:{rm}:{rs}");
            Console.WriteLine("I am ready!");
        }
        public void Start(){
            if(args.nowhour==0&&args.nowminute==0&&args.nowsecond==0&&args.ringhour==0&&args.ringminute==0&&args.ringsecond==0){
                throw new ArgumentNullException("Thetimehasnotbeenset!");
            }
            Console.WriteLine("This is when time begins to flow!");
            int startsecond=System.DateTime.Now.Second;
            while(!(args.ringhour==args.nowhour&&args.ringminute==args.nowminute&&args.ringsecond==args.nowsecond)){
                if(System.DateTime.Now.Second!=startsecond){
                    startsecond=System.DateTime.Now.Second;
                    args.nowsecond++;
                    if(args.nowsecond==60){
                        args.nowsecond=0;
                        args.nowminute++;
                        if(args.nowminute==60){
                            args.nowminute=0;
                            args.nowhour++;
                            if(args.nowhour==24) args.nowhour=0;
                        }
                    }
                    Ticktack(this,args);
                }
            }
            Ring(this,args);
        }
    }

    public class Form{
        public AlarmClock alarmc=new AlarmClock();
        public Form(){
            alarmc.Ticktack+=new AlarmHandler(AC_ticktack);
            alarmc.Ring+=AC_ring;
        }
        void AC_ticktack(object sneder,SetalarmEventArgs args){
            Console.WriteLine($"tick {args.nowhour}:{args.nowminute}:{args.nowsecond} tack!");
        }
        void AC_ring(object sneder,SetalarmEventArgs args){
            Console.WriteLine("Ringgggggggggggggggggg!!!");
        }
    }
}
