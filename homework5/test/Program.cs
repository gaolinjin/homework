using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //-------------------客户----------------------
            Customer JackMa=new Customer("Jack Ma");
            Customer LeiJun=new Customer("Lei Jun");
            //-------------------客户----------------------

            //-------------------商品----------------------
            Product hdnoodle=new Product("hd noodles",5);
            Product dumpling=new Product("dumpling",8);
            Product baozi=new Product("bao zi",2);
            Product hamburger=new Product("hamburger",10);
            Product xiaomi=new Product("xiao mi",3000);
            //-------------------商品----------------------

            //-------------------测试代码--------------------

            Console.WriteLine(baozi);//测试商品类ToString

            //----------------创立订单和订单项--------------
            Order o1=new Order(JackMa);
            Order o2=new Order(LeiJun);
            OrderDetails o_1=new OrderDetails(baozi,100);
            OrderDetails o_2=new OrderDetails(hamburger,50);
            OrderDetails o_3=new OrderDetails(dumpling,30);
            OrderDetails o_4=new OrderDetails(hdnoodle,100);
            OrderDetails o_5=new OrderDetails(dumpling,200);
            //----------------创立订单和订单项--------------

            //----------------增删改订单和订单项--------------
            OrderService.AddOrder(o1);
            OrderService.AddOrder(o1);
            OrderService.AddOrderitem(o1,o_1);
            OrderService.AddOrderitem(o1,o_2);
            OrderService.AddOrderitem(o1,o_2);
            Console.WriteLine(o1);
            OrderService.AddOrder(o2);
            OrderService.AddOrderitem(o2,o_4);
            OrderService.AddOrderitem(o2,o_5);
            OrderService.DeleteOrderitem(o1,o_2);
            OrderService.ChangeOrderitme(o1,o_1,o_3);
            OrderService.AddOrderitem(o2,o_1);
            //----------------增删改订单和订单项--------------

            //----------------对全部订单排序输出--------------
            OrderService.Disp_order();
            Console.WriteLine("Sort by id lambda");
            OrderService.blanket_order.Sort((p1,p2)=>p1.Id-p2.Id);
            foreach (var item in OrderService.blanket_order)
            {
                Console.WriteLine(item);
            }
            //----------------对全部订单排序输出--------------

            Console.WriteLine($"Is o1 equals to o2?: {o1.Equals(o2)}");//测试equal();

            //---------------按指定信息查找订单---------------
            Console.WriteLine("以下输出id为2的订单：\n");
            OrderService.GetOrderbyid(2);
            Console.WriteLine("以下输出含有dumplings的订单：\n");
            OrderService.GetOrder(dumpling);
            Console.WriteLine("以下输出含有xiaomi的订单：\n");
            OrderService.GetOrder(xiaomi);
            Console.WriteLine("以下输出leijun的订单：\n");
            OrderService.GetOrder("Lei Jun");
            Console.WriteLine("以下输出金额2300的订单：\n");
            OrderService.GetOrder(2300);
            //---------------按指定信息查找订单---------------


        }
    }
    
    class Order:IComparable{
        //保护数据私有，又公共可读；
        private int id;
        public int Id{get=>id;}
        private string disp_id;//显示出来的订单编号
        public string Disp_id{get=>disp_id;}
        private string customername;
        public string Customername{get=>customername;}
        private int totalamount;
        public int Totalamount{get=>totalamount;}

        private static int uid=0;//计数订单数量用于自动生成订单编号
        public Order(Customer cn){
            uid++;
            id=uid;
            customername=cn.ToString();
            //------将数字订单id转化成字符串订单编号------
            int x=0;
            int y=this.Id;
            while(y>0){
                x++;
                y/=10;
            }
            while(6-x>0){
                disp_id+="0";
                x++;
            }
            disp_id+=this.Id;
            //------将数字订单id转化成字符串订单编号------
        }
        public Order(){}
        
        public List<OrderDetails> orderitem=new List<OrderDetails>();

        public void aggregateamount(){//计算订单中所有项总金额；
            totalamount=0;
            foreach (var s in orderitem)
            {
                totalamount+=s.Amount;
            }
        }

        public int CompareTo(Object obj){
            if(!(obj is Order))throw new ArgumentNullException("存在非订单实例");
            Order o=(Order) obj;
            return o.Totalamount.CompareTo(this.Totalamount);
        }

        public override bool Equals(object obj)
        {
            Order o=obj as Order;
            return o!=null&&o.Id==id;
        }
        public override int GetHashCode()
        {
            return id;
        }
         
        public override string ToString(){//以订单列表的形式输出
            string m=$"id:{disp_id}      customer:{customername}\n";
            m+="-----name-----|--price--|--quantity--|\n";
            foreach (var s in orderitem)
            {
                m+=s.ToString();
                m+="\n";
            }
            m+="--------------------------------------\n";
            m+=$"totalamount:{totalamount}\n";
            return m;
        }
    }
    class OrderDetails:Order{
        public new int Id{get;set;}
        private Product p;//货物
        public Product P{get=>p;}
        private int productquantity;//商品订购数量
        public int Productquantity{get=>productquantity;}
        private int amount;
        public int Amount{get=>amount;}
        public OrderDetails(Product p,int q){
            this.p=p;
            productquantity=q;
            
            amount=this.p.Price*productquantity;
        }

        public override bool Equals(object obj)
        {
            OrderDetails o=obj as OrderDetails;
            return o!=null&&o.P==p&&o.Productquantity==productquantity;
        }
        public override int GetHashCode()
        {
            return amount;
        }
        public override string ToString(){
            return String.Format("{0,14}",p.Name)+"| "+String.Format("{0,8}",p.Price)+"|"+String.Format("{0,12}",productquantity)+"|";
        }
    }
    class OrderService{
        public static List<Order> blanket_order=new List<Order>();
        public static List<OrderDetails> blanket_orderitem=new List<OrderDetails>();
        public static void Disp_order(){
            Console.WriteLine("按总金额排行输出全部订单");
            blanket_order.Sort();
            foreach (var item in blanket_order)
            {
                Console.WriteLine(item);
            }
        }
        public static void AddOrder(Order o){//添加一个订单
            if(blanket_order.Contains(o)){
                Console.WriteLine("已有此订单");
            }else blanket_order.Add(o);           
            
        }
        public static void AddOrderitem(Order o,OrderDetails od){//为一个订单添加一个订单项
            if(o.orderitem.Contains(od)){
                Console.WriteLine("该订单已有此订单项");
            }else{
                od.Id=o.Id;
                blanket_orderitem.Add(od);
                o.orderitem.Add(od);
                o.aggregateamount();
            }
            
        }

        public static void DeleteOrder(Order o){//删除整个订单
            if(blanket_order.Contains(o)){
                blanket_order.Remove(o);
                foreach (var item in o.orderitem)
                {
                    blanket_orderitem.Remove(item);
                }
            }else throw new ArgumentNullException("illegal!There is no such order");

        }
        public static void DeleteOrderitem(Order o,OrderDetails od){//删除一个订单项
            if(o.orderitem.Contains(od)){
                o.orderitem.Remove(od);
                blanket_orderitem.Remove(od);
                o.aggregateamount();
            }else throw new ArgumentNullException("illegal!There is no such orderitem");

        }

        public static void ChangeOrderitme(Order o,OrderDetails od,OrderDetails odn){//调用增删来修改一个订单项
            DeleteOrderitem(o,od);
            AddOrderitem(o,odn);
            o.aggregateamount();
        }
        public static void GetOrderbyid(int id){
            var result=from s in blanket_order
                where s.Id==id
                select s;
            if(result.Count()==0) Console.WriteLine("没有此订单");
            foreach (var item in result)
                {
                   Console.WriteLine(item); 
                }
        }
        public static void GetOrder(Product p){
            var id=from s in blanket_orderitem
                where s.P==p
                select s.Id;
            var l=from s in blanket_order
                where id.Contains(s.Id)
                orderby s.Totalamount descending
                select s;
            if(l.Count()==0) Console.WriteLine("没有此订单");
            foreach (var item in l)
                {
                   Console.WriteLine(item); 
                }
        }
        public static void GetOrder(string c){
            var l=from s in blanket_order
                where s.Customername==c
                orderby s.Totalamount descending
                select s;
            if(l.Count()==0) Console.WriteLine("没有此订单");
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }
        public static void GetOrder(int m){
            var l=from s in blanket_order
                where s.Totalamount==m
                select s;
            if(l.Count()==0) Console.WriteLine("没有此订单");
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }
        
    }
    class Customer{
        private string name;
        public Customer(string n){
            name= n;
        }
        public override string ToString(){
            return name;
        }
    }
    class Product{
        public string Name{get;set;}
        public int Price{get;set;}
        public Product(string n,int p){
            this.Name=n;
            this.Price=p;
        }
        public override string ToString(){
            return "Productname:"+this.Name+"  price:"+this.Price;
        }
    }
}
