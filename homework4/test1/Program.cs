using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> inlist=new GenericList<int>();
            for(int i=0;i<9;i++){
                inlist.Add(i);
            }
            int max=0;
            int min=0;
            int sum=0;
            inlist.ForEach(m=>Console.WriteLine(m));
            inlist.ForEach(m=>{
                if(m>max)max=m;
                if(m<min)min=m; });
            inlist.ForEach(m=>sum+=m);    
            Console.WriteLine($"Max:{max} Min:{min}");
            Console.WriteLine($"Sum:{sum}");
        }
    }
    public class Node<T>{
        public Node<T> Next{get;set;}
        public T Data{get;set;}
        public Node(T t){
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>{
        private Node<T> head;
        private Node<T> tail;

        public void ForEach(Action<T> action){
            Node<T> p=this.Head;
            while(p!=null){
                action(p.Data);
                p=p.Next;
            }
        }
        public GenericList(){
            tail = head = null;
        }
        public Node<T> Head{
            get=>head;
        }
        public void Add(T t){
            Node<T> n =new Node<T>(t);
            if(tail == null){
                head = tail = n;
            }else{
                tail.Next=n;
                tail=n;
            }            
        }
    }
}
